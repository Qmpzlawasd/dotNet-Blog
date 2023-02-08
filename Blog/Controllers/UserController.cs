using Blog.Enums;
using Blog.Helper;
using Blog.Models;
using Blog.Models.DTOs;
using Blog.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Create(AppUserDTO givenUser)
    {
        var userObj = new AppUser
        {
            Username = givenUser.Username,
            Email = givenUser.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(givenUser.Password),
            Sex = givenUser.Sex
        };
        await _userService.Create(userObj);

        return Ok(userObj);
    }

    [Authorization(Role.Admin)]
    [HttpGet("BecomeWriter")]
    public async Task<IActionResult> BecomeWriter(Guid userId)
    {
        var writer = await _userService.BecomeWriter(userId);
        return Ok(writer);
    }

    [HttpGet("GetWriters")]
    public ActionResult<AppUser> GetWriters()
    {
        var writers = _userService.GetWriters();

        return Ok(writers);
    }

    [HttpPost("LikePost")]
    public ActionResult LikePost(Guid userId, Guid blogId)
    {
        var good = _userService.LikePost(userId, blogId);
        if (!good)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AppUserRequestDTO user)
    {
        var response = _userService.Authenticate(user);
        if (response == null)
        {
            return BadRequest("invalid username or password");
        }

        return Ok(response);
    }

    [HttpGet("info/{id}")]
    public async Task<UserDataDTO> GetInfo([FromRoute] Guid id)
    {
        var a = await _userService.GetByIdAsync(id);
        var b = new UserDataDTO
        {
            Email = a.Email,
            Sex = a.Sex,
            Username = a.Username
        };
        return b;
    }
}