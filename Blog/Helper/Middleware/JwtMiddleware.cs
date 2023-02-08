using Blog.Migrations.JwtToken;
using Blog.Services.User;

namespace Blog.Helper.Middleware;

public class JwtMiddleware
{

    private readonly RequestDelegate _nextRequestDelegate;

    public JwtMiddleware(RequestDelegate requestDelegate)
    {
        _nextRequestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtilils)
    {
        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();

        var userId = jwtUtilils.ValidateJwtToken(token!);

        if (userId != Guid.Empty)
        {
            httpContext.Items["AppUser"] = await userService.GetByIdAsync(userId);
        }

        await _nextRequestDelegate(httpContext);
    }

}