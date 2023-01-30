using Blog.Models;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.BlogPostRepository;

public interface IBlogPostRepository : IGenericRepository<BlogPost>
{
}