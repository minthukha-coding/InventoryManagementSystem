using InventoryManagementSystemApi.Modles.Setup.Token;

namespace InventoryManagementSystemApi.Shared.Service;

public class JwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public JwtTokenService(
        IConfiguration configuration,
        JwtSecurityTokenHandler tokenHandler)
    {
        _configuration = configuration;
        _tokenHandler = tokenHandler;
    }

    public string GenerateJwtToken(AccessTokenRequestModel requestModel)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, requestModel.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal ReadJwtToken(string token)
    {
        var key = (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };

        try
        {
            var principal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
            return principal;
        }
        catch
        {
            return null;
        }
    }
}