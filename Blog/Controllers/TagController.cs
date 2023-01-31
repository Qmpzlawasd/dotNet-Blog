using Blog.Models;
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
        var newCategory = new Category
        {
            Name = givenData.Name,
            Description = givenData.Description
        };
        await _tagService.CreateCategory(newCategory);
        return Ok(newCategory);
    }
}