using InventoryManagementSystemApi.Modles.Setup.Authenation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystemApi.Features.Authenation;

[Route("api/signIn")]
[ApiController]
public class SignInController : ControllerBase
{
    private readonly BL_SignIn _blSignIn;

    public SignInController(BL_SignIn blSignIn)
    {
        _blSignIn = blSignIn;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInRequestModel reqModel)
    {
        try
        {
            var model = await _blSignIn.SignIn(reqModel);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }
}
