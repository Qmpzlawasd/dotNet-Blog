using Blog.Models;
using Blog.Models.DTOs;

namespace Blog.Services.User;

public interface IUserService
{
    public AppUserResponseDTO? Authenticate(AppUserRequestDTO model);
    public Task Create(AppUser newUser);
    public  Task<AppUser> BecomeWriter(Guid id);
    public List<AppUser> GetWriters();
    public bool LikePost(Guid userId, Guid blogId);
    public Task<AppUser?> GetByIdAsync(Guid id);

}