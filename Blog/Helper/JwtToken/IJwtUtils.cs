using Blog.Models;

namespace Blog.Migrations.JwtToken;

public interface IJwtUtils
{
    public string GenerateJwtToken(AppUser user);
    public Guid ValidateJwtToken(string token);
    
}