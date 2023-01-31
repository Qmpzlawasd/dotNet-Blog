using Blog.Migrations.JwtToken;
using Blog.Models;
using Blog.Models.DTOs;
using Blog.Repositories;

namespace Blog.Services.User;

public class UserService : IUserService
{
    private IUnitOfWork _unitOfWork;
    private IJwtUtils _jwtUtils;

    public UserService(IUnitOfWork unitOfWork, IJwtUtils jwtUtils)
    {
        _unitOfWork = unitOfWork;
        _jwtUtils = jwtUtils;
    }

    public AppUserResponseDTO Authenticate(AppUserRequestDTO model)
    {
        var user = _unitOfWork.AppUserRepository.FindByUsername(model.Username);
        if (user == null  || !BCrypt.Net.BCrypt.Verify(model.Password,user.Password))
        {
            return null;
        }
        var jwt = _jwtUtils.GenerateJwtToken(user);
        var newuser = new AppUserResponseDTO
        {
            Username = user.Username,
            Password = user.Password,
            Token = jwt
        };
        return newuser;
    }
    public async Task Create(AppUser newUser)
    {
        await _unitOfWork.AppUserRepository.CreateAsync(newUser);
        await _unitOfWork.SaveAsync();
    }   
    public async Task<AppUser> BecomeWriter(Guid id)
    {
         var user = _unitOfWork.AppUserRepository.FindById(id);
         user.Writer = new Writer
         {
             UserId = user.Id,
             BlogPostsWritten = 0
         };
         await _unitOfWork.SaveAsync();
         return user;
    }
    public List<AppUser> GetWriters()
    {
        var writers =  _unitOfWork.AppUserRepository.GetWriters();
        return writers;
    }
    public bool LikePost(Guid userId, Guid blogId)
    {
        var likke = new Like
        {
            UserId = userId,
            BlogPostId = blogId
        };
        var post = _unitOfWork.BlogPostRepository.FindById(blogId);
        if (post.Likes== null)
        {
            post.Likes= new List<Like>();
        }
        post.Likes.Add(likke);
        _unitOfWork.SaveAsync();
        return true;
    }

}