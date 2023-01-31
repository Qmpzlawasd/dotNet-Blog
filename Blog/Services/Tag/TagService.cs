using Blog.Models;
using Blog.Repositories;

namespace Blog.Services.Tag;

public class TagService : ITagService
{
    private IUnitOfWork _unitOfWork;
    public TagService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCategory(Category cat)
    {
        await _unitOfWork.CategoryRepository.CreateAsync(cat);
        await _unitOfWork.SaveAsync();
    }
   
}