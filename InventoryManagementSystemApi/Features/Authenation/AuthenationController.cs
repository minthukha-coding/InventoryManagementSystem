using InventoryManagementSystemApi.Modles.Setup.Authenation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagementSystemApi.Features.Authenation;

[Route("api/authenation")]
[ApiController]
public class AuthenationController : ControllerBase
{
    private readonly BL_Authenation _authenation;

    public AuthenationController(BL_Authenation authenation)
    {
        _authenation = authenation;
    }

    [HttpPost("/signIn")]
    public async Task<IActionResult> SignIn(SignInRequestModel reqModel)
    {
        try
        {
            var model = await _authenation.SignIn(reqModel);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }

    [HttpPost("/signOut")]
    public async Task<IActionResult> SignOut(string accessToken)
    {
        try
        {
            var model = await _authenation.SignOut(accessToken);
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
        }
    }
}
