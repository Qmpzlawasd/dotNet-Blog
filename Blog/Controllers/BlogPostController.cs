using Blog.Models;
using Blog.Services.BlogPost;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostController : Controller
{
    private readonly IBlogPostService _blogPostService;
    public BlogPostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpGet("delete/{blogId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid blogId)
    {
        return Ok();
    }
    // [HttpGet("getAll")]
    // public async IAsyncEnumerable<BlogPost> GetAll()
    // {
    //     return _blogPostService.GetAll();
    // }
    [HttpGet("getBlogPostComments/{blogId}")]
    public async Task<IActionResult> GetBlogPostComments([FromRoute] Guid blogId)
    {
        // select  * from comm where id  = blogId;
        // var a  = 
        return Ok();
    }
    [HttpPost("AddComment/{blogId}")]
    public async Task<IActionResult> AddComment([FromRoute] Guid blogId)
    {
        return Ok();
    }
    
    [HttpPost("getBlogPostRecentComments/{blogId}")]
    public async Task<IActionResult> GetBlogPostRecentComments([FromRoute] Guid blogId)
    {
        //select   * from  (select  * from comm where id  = blogId order by dateCreated) where rownum < 3; 
        return Ok();
    }
}