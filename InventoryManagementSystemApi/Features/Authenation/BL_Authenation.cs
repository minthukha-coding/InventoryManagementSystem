using InventoryManagementSystemApi.Modles.Authenation;
using InventoryManagementSystemApi.Shared;

namespace InventoryManagementSystemApi.Features.Authenation;

public class BL_Authenation
{
    private readonly DA_Authenation _daAuthenation;

    public BL_Authenation(DA_Authenation daAuthenation)
    {
        _daAuthenation = daAuthenation;
    }

    public async Task<Result<SignInResponseModel>> SignIn(SignInRequestModel reqModel)
    {
        Result<SignInResponseModel> model;
        model = await _daAuthenation.SignIn(reqModel);
        return model;
    }
    
    public async Task<Result<string>> SignOut(string accessToken)
    {
        Result<string> model;
        model = await _daAuthenation.SignOut(accessToken);
        return model;
    }

    public async Task<Result<string>> Register(RegisterRequestModel reqModel)
    {
        Result<string> result = await _daAuthenation.Register(reqModel);
        return result;
    }

}
