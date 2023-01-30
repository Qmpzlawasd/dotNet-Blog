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

    // [HttpGet("getUserData/{id}")]
    // public async ActionResult<AppUserDTO> getUserData([FromRoute] Guid id)
    // {
    //     var outp = _userService.GetById(id);
    //     var response = new UserResponseDTO
    //     {
    //         Username  = outp.
    //         Email = outp.
    //         Sex = outp.
    //     };
    //     return Ok(response);
    // }

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
}