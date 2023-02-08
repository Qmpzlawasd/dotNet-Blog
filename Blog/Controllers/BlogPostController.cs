using Blog.Enums;
using Blog.Helper;
using Blog.Models;
using Blog.Models.DTOs;
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

    [Authorization(Role.Admin)]
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteBlogPost(Guid id)
    {
        await _blogPostService.Delete(id);

        return Ok();
    }

    [HttpPost("makePost")]
    public async Task<ActionResult<BlogPost>> CreatePost(BlogPostDTO newPost)
    {
        var postToCreate = new BlogPost
        {
            Title = newPost.Title,
            Text = newPost.Text,
            Language = newPost.Language,
            WriterId = newPost.Writer_id
        };
        await _blogPostService.CreatePost(postToCreate);

        return Ok(postToCreate);
    }

    [HttpPost("attachTag")]
    public async Task<ActionResult> AttachTag(Guid blogId, Guid categoryId)
    {
        var good = _blogPostService.AttachTag(blogId, categoryId);
        if (!good)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("newTitle")]
    public async Task<ActionResult> UpdateTitle(string newTitle, BlogPostDTO post)
    {
        var back = await _blogPostService.UpdateTitle(newTitle, post);
        if (!back)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpGet("GetTags")]
    public ActionResult<List<string>> GetPostTags(Guid postId)
    {
        var tags = _blogPostService.GetPostTags(postId);
        return tags;
    }

    [HttpGet("GetTopPostsByLikes")]
    public ActionResult<BestBlogPostsDTO> GetTopPostsByLikes()
    {
        var orderedPosts = _blogPostService.GetTopPostsByLikes();
        return Ok(orderedPosts);
    }
}