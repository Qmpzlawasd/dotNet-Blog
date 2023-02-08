using Blog.Enums;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Helper;

public class Authorization : Attribute, IAuthorizationFilter
{
    private readonly ICollection<Role> _roles;

    public Authorization(params Role[] roles)
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var errorStatusObject =
            new JsonResult(new { Message = "Unauthorized" });

        var user = (AppUser?)context.HttpContext.Items["AppUser"];
        if (_roles == null || user == null)
        {
            errorStatusObject.StatusCode = StatusCodes.Status401Unauthorized;
            context.Result = errorStatusObject;
            return;
        }

        if (!_roles!.Contains(user.Role))
        {
            errorStatusObject.StatusCode = StatusCodes.Status403Forbidden;
            context.Result = errorStatusObject;
        }
    }
}