using Blog.Data;
using Blog.Models;
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
}