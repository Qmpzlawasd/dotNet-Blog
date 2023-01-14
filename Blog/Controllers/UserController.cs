using Blog.Data;
using Blog.Models;
using Blog.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller

{
    private BlogContext _BlogContext;

    public UserController(BlogContext context)
    {
        _BlogContext = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _BlogContext.Users.ToListAsync());
    }

    [HttpGet("getUserData{id}")]
    public async Task<IActionResult> getUserData([FromRoute] Guid identif)
    {
        var user = _BlogContext.Users.FirstOrDefault(userObj => userObj.Id == identif);
        return Ok(user);
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> Create(UserDTO givenUser)
    {
        var newUser = new User();
        newUser.Username = givenUser.Username;
        newUser.Email = givenUser.Email;
        newUser.Password = givenUser.Password;
        await _BlogContext.AddAsync(newUser);
        await _BlogContext.SaveChangesAsync();
        return Ok(newUser);
    }
}