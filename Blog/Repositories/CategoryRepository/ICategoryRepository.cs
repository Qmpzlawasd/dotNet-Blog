using Blog.Models;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.CategoryRepository;

public interface ICategoryRepository : IGenericRepository<Category>
{
    
}