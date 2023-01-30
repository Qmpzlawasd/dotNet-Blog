using Blog.Data;
using Blog.Models;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.BlogPostRepository;

public class BlogPostRepositoy : GenericRepository<BlogPost>, IBlogPostRepository
{
    public BlogPostRepositoy(BlogContext context) : base(context)
    {
    }
}