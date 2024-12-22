using InventoryManagementSystemApi.Modles.Setup.Authenation;
using InventoryManagementSystemApi.Shared.Service;

namespace InventoryManagementSystemApi.Features.Authenation;

public class DA_Authenation
{
    private readonly AppDbContext _db;
    private readonly JwtTokenService _jwtTokenService;
    private readonly ILogger<DA_Authenation> _logger;

    public DA_Authenation(
        AppDbContext db,
        ILogger<DA_Authenation> logger,
        JwtTokenService jwtTokenService)
    {
        _db = db;
        _logger = logger;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<string>> Register(RegisterRequestModel reqModel)
    {
        Result<string> result;

        try
        {
            var existingUser = await _db.TblUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName == reqModel.UserName);

            if (existingUser != null)
            {
                result = Result<string>.FailureResult("Username already exists.");
                return result;
            }

            var pasword = reqModel.Password;

            var newUser = new TblUser
            {
                UsereId = Guid.NewGuid().ToString(),
                UserName = reqModel.UserName,
                HashPassword = pasword,
                Role = reqModel.Role,
                CreatedDateTime = DateTime.Now,
                IsDeleted = 0
            };

            newUser.HashPassword = pasword.ToSHA256HexHashString(newUser.UsereId);

            _db.TblUsers.Add(newUser);
            await _db.SaveChangesAsync();

            result = Result<string>.SuccessResult("User registered successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while registering user.");
            result = Result<string>.FailureResult("Registration failed due to an internal error.");
        }

        return result;
    }

    public async Task<Result<SignInResponseModel>> SignIn(SignInRequestModel reqModel)
    {
        Result<SignInResponseModel> model;
        var item = await _db.TblUsers
            .AsNoTracking()
            .Where(x => x.UserName == reqModel.UserName)
            .FirstOrDefaultAsync();

        if (item is null)
        {
            model = Result<SignInResponseModel>.FailureResult("Login Failed.");
            goto Result;
        }

        var hashPass = reqModel.HashPassword.ToSHA256HexHashString(item.UsereId);

        if (item.HashPassword != hashPass)
        {
            model = Result<SignInResponseModel>.FailureResult("Password Failed");
            goto Result;
        }

        var tokenRequestModel = new AccessTokenRequestModel
        {
            UserName = item.UserName,
            UserPassword = item.HashPassword
        };
        var accessToken = _jwtTokenService
            .GenerateJwtToken(reqModel.UserName, reqModel.HashPassword);

        await SaveLogin(item, accessToken);

        model = Result<SignInResponseModel>.SuccessResult(new SignInResponseModel(accessToken));

        Result:
        return model;
    }

    public async Task<Result<string>> SignOut(string accessToken)
    {
        Result<string> model;
        var item = _db.TblLogins
            .Where(x => x.AccessToken == accessToken)
            .FirstOrDefault();
        if (item is null)
        {
            model = Result<string>.FailureResult("SignOut fail -- AccessToken is not valid");
            goto result;
        }

        item.LogoutDate = DateTime.Now;

        _db.TblLogins.Update(item);
        await _db.SaveChangesAsync();

        model = Result<string>.SuccessResult("SignOut Success");

        result:
        return model;
    }

    #region SaveLogin

    private async Task SaveLogin(TblUser userData, string accessToken)
    {
        var login = new TblLogin
        {
            UserId = userData.UsereId,
            Role = userData.Role,
            AccessToken = accessToken,
            LoginDate = DateTime.Now,
            Email = userData.UserName,
            LogoutDate = DateTime.Now
        };
        _db.TblLogins.Add(login);
        await _db.SaveChangesAsync();
    }

    #endregion
}