using Blog.Models;

namespace Blog.Services.Tag;

public interface ITagService
{
    public Task CreateCategory(Category cat);
}