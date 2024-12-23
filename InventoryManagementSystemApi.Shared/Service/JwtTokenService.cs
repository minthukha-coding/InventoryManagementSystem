﻿namespace InventoryManagementSystemApi.Shared.Service;

public class JwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public JwtTokenService(IConfiguration configuration,
        JwtSecurityTokenHandler tokenHandler)
    {
        _configuration = configuration;
        _tokenHandler = tokenHandler;
    }

    public string GenerateJwtToken(string userName, string password)
    {
        //var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);
        var key = Encoding.ASCII.GetBytes("your_very_long_secret_key_1234567890");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Email, password)
            }),
            Expires = DevCode.GetServerDateTime().AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = _tokenHandler.CreateToken(tokenDescriptor);
        return _tokenHandler.WriteToken(token);
    }


    public ClaimsPrincipal ReadJwtToken(string token)
    {
        var key = Encoding.ASCII.GetBytes("your_very_long_secret_key_1234567890");
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