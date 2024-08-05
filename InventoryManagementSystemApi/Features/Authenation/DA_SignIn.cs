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

public class DA_SignIn
{
    private readonly AppDbContext _db;
    private readonly ILogger _logger; JwtTokenService _jwtTokenService;
    public DA_SignIn(AppDbContext db, JwtTokenService jwtTokenService)
    {
        _db = db;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<SignInResponseModel>> SignIn(SignInRequestModel reqModel)
    {
        Result<SignInResponseModel> model;

        var item = await _db.TblUsers
            .AsNoTracking()
            .Where(x => x.UserName == reqModel.UserName &&
                        x.HashPassword == reqModel.UserPassword)
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
            .GenerateJwtToken(reqModel.UserPassword,reqModel.UserPassword);

        model = Result<SignInResponseModel>.SuccessResult(new SignInResponseModel(accessToken));

    Result:
        return model;
    }
}
