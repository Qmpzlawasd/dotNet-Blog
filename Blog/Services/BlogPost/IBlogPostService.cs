using Blog.Models.DTOs;

namespace Blog.Services.BlogPost;

public interface IBlogPostService
{
    // public Task<IAsyncEnumerable<string>> GetBlogPostComments(Guid blogId);
    public Task Delete(Guid id);
    public Task CreatePost(Models.BlogPost post);
    public bool AttachTag(Guid blogId, Guid categoryId);
    public Task<bool> UpdateTitle(string title, BlogPostDTO post);
    public List<string> GetPostTags(Guid postId);
    public List<BestBlogPostsDTO> GetTopPostsByLikes();
    public Task<Models.BlogPost?> GetByIdAsync(Guid id);
}