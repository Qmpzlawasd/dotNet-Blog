using Blog.Repositories;

namespace Blog.Services.Tag;

public class TagService : ITagService
{
    private IUnitOfWork _unitOfWork;

    public TagService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }   
}