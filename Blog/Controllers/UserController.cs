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

    [HttpGet("BecomeWriter")]
    public async Task<IActionResult> BecomeWriter(Guid userId)
    {
        var writer = await _userService.BecomeWriter(userId);
        return Ok(writer);
    }

    [HttpGet("GetWriters")]
    public async Task<ActionResult<AppUser>> GetWriters()
    {
        var writers = _userService.GetWriters();

        return Ok(writers);
    }

    [HttpPost("LikePost")]
    public async Task<ActionResult> LikePost(Guid userId, Guid blogId)
    {
        var good = _userService.LikePost(userId, blogId);
        if (!good)
        {
            return BadRequest();
        }

        return Ok();
    }
}