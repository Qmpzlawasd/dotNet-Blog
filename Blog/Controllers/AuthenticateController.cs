using Blog.Models.DTOs;
using Blog.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
public class AuthenticateController : ControllerBase
{
    private IUserService _userService;

    public AuthenticateController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login(AppUserRequestDTO request)
    {
        var res = _userService.Authenticate(request);
        if (res == null)
        {
            return Forbid();
        }

        return Ok(res);
    }
}