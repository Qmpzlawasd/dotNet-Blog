using Blog.Models.DTOs;
using Blog.Repositories;

namespace Blog.Services.BlogPost;

public class BlogPostService : IBlogPostService
{
    private IUnitOfWork _unitOfWork;
    public BlogPostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    // public Task<IAsyncEnumerable<string>> GetBlogPostComments(Guid blogId)
    // {
    //     return _unitOfWork.BlogPostRepository.GetComments(blogId);
    // }
    public async Task Delete(Guid id)
    {
        var post = await _unitOfWork.BlogPostRepository.FindByIdAsync(id);
        _unitOfWork.BlogPostRepository.Delete(post);
        await _unitOfWork.SaveAsync();
    }
    public async Task CreatePost(Models.BlogPost post)
    {
        await _unitOfWork.BlogPostRepository.CreateAsync(post);
        await _unitOfWork.SaveAsync();
    }
    public bool AttachTag(Guid blogId, Guid categoryId)
    {
        var post = _unitOfWork.BlogPostRepository.FindById(blogId);
        var cat = _unitOfWork.CategoryRepository.FindById(categoryId);
        var ad = new Models.Tag
        {
            CategoryId = categoryId,
            BlogPostId = blogId
        };
        if (post.Tags == null)
        {
            post.Tags = new List<Models.Tag>();
        }
        post.Tags.Add(ad);
        _unitOfWork.SaveAsync();
        return true;
    }
    public async Task<bool> UpdateTitle(string title, BlogPostDTO post)
    {
        var postObj =  _unitOfWork.BlogPostRepository.FindByTitle(post.Title);
        if (postObj == null)
        {
            return false;
        }
        postObj.Title = title;
        await _unitOfWork.SaveAsync();
        return true;
    }
    public List<string> GetPostTags(Guid postId)
    {
        var tags =  _unitOfWork.BlogPostRepository.GetTags(postId);
        return tags;
    }
    public  List<BestBlogPostsDTO> GetTopPostsByLikes()
    {
        return  _unitOfWork.BlogPostRepository.GetTopPostsByLikes();
    }
}