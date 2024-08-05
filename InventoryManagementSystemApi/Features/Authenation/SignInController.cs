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
    [HttpPost("signIn")]
    public async Task<IActionResult> SignIn([FromBody] UserModel reqModel)
    {
        if (reqModel.UserName != "test" || reqModel.UserPassword != "password")
            return Unauthorized();
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, reqModel.UserName)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        // Return the token
        return Ok(new { Token = tokenString });
    }
}
