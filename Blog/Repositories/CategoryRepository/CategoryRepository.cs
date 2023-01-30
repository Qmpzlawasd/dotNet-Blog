using Blog.Data;
using Blog.Models;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.CategoryRepository;

public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
{
    public CategoryRepository(BlogContext context) : base(context)
    {
    }
    
}