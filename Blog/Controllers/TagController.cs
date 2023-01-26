using Blog.Models.DTOs;
using Blog.Services.Tag;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CategoryDTO givenData)
    {
        
        return Ok();
    }
}