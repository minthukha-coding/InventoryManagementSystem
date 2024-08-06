using InventoryManagementSystemApi.Modles.Setup.Authenation;
using InventoryManagementSystemApi.Shared;

namespace InventoryManagementSystemApi.Features.Authenation;

public class BL_SignIn
{
    private readonly DA_SignIn _daSignIn;

    public BL_SignIn(DA_SignIn daSignIn)
    {
        _daSignIn = daSignIn;
    }

    public async Task<Result<SignInResponseModel>> SignIn(SignInRequestModel reqModel)
    {
        Result<SignInResponseModel> model;
        model = await _daSignIn.SignIn(reqModel);
        return model;
    }
    
    public async Task<Result<string>> SignOut(string accessToken)
    {
        Result<string> model;
        model = await _daSignIn.SignOut(accessToken);
        return model;
    }
}
