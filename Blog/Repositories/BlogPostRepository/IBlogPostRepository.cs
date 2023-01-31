using Blog.Models;
using Blog.Models.DTOs;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.BlogPostRepository;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
    public BlogPost? FindByTitle(string title);
    public List<string> GetTags(Guid postId);


    public List<BestBlogPostsDTO> GetTopPostsByLikes();

}