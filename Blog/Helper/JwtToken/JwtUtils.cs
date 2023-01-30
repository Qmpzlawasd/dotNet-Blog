using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using Blog.Models;
using System.Text;
using Blog.Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Migrations.JwtToken;

public class JwtUtils : IJwtUtils
{
    public readonly AppSettings _appSettings;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string GenerateJwtToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var appPK = Encoding.ASCII.GetBytes(_appSettings.JwtToken);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(14),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(appPK), SecurityAlgorithms.EcdsaSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public Guid ValidateJwtToken(string token)
    {
        if (token == null)
        {
            return Guid.Empty;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var appPK = Encoding.ASCII.GetBytes(_appSettings.JwtToken);
        var TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(appPK),
            ValidateIssuer = true,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        try
        {
            tokenHandler.ValidateToken(token, TokenValidationParameters, out SecurityToken validatedToken);
            var jwt = (JwtSecurityToken)validatedToken;
            var userId = new Guid(jwt.Claims.FirstOrDefault(x => x.Type == "id").Value);
            return userId;
        }
        catch (Exception)
        {
            return  Guid.Empty;
        }
    }
}