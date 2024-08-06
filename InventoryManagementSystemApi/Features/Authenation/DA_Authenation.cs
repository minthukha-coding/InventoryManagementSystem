using Azure.Core;
using InventoryManagementSystemApi.DbService.Db;
using InventoryManagementSystemApi.Modles.Setup.Authenation;
using InventoryManagementSystemApi.Modles.Token;
using InventoryManagementSystemApi.Shared;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystemApi.Features.Authenation;

public class DA_Authenation
{
    private readonly AppDbContext _db;
    private readonly ILogger<DA_Authenation> _logger; 
    private readonly JwtTokenService _jwtTokenService;

    public DA_Authenation(AppDbContext db,
        ILogger<DA_Authenation> logger, 
        JwtTokenService jwtTokenService)
    {
        _db = db;
        _logger = logger;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<SignInResponseModel>> SignIn(SignInRequestModel reqModel)
    {
        Result<SignInResponseModel> model;

        try
        {
            var item = await _db.TblUsers
           .AsNoTracking()
           .Where(x => x.UserName == reqModel.UserName &&
                       x.HashPassword == reqModel.HashPassword)
            .FirstOrDefaultAsync();
            
            if (item is null)
            {
                model = Result<SignInResponseModel>.FailureResult("Login Failed.");
                goto Result;
            }
            var tokenModel = new AccessTokenRequestModel
            {
                UserName = item.UserName,
                UserPassword = item.HashPassword
            };
            string accessToken = _jwtTokenService
                .GenerateJwtToken(reqModel.UserName, reqModel.HashPassword);

            await SaveLogin(item, accessToken);

            model = Result<SignInResponseModel>.SuccessResult(new SignInResponseModel(accessToken));
        }
        
        catch (Exception)
        {

            throw;
        }

    Result:
        return model;
    }

    public async Task<Result<string>> SignOut(string accessToken)
    {
        Result<string> model;
        var item = _db.TblLogins
            .Where( x => x.AccessToken == accessToken )
            .FirstOrDefault();
        if(item is null )
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

    private async Task SaveLogin(TblUser userData, string accessToken)
    {
        try
        {
            var login = new TblLogin()
            {
                UserId = userData.UsereId,
                AccessToken = accessToken,
                LoginDate = DateTime.UtcNow,
            };
            await _db.TblLogins.AddAsync(login);
            await _db.SaveChangesAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
