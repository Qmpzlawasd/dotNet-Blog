using Blog.Repositories;

namespace Blog.Services.BlogPost;

public class BlogPostService : IBlogPostService
{
    private IUnitOfWork _unitOfWork;

    public BlogPostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}