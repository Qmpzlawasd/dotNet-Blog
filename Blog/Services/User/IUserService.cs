using Blog.Models;
using Blog.Models.DTOs;

namespace Blog.Services.User;

public interface IUserService
{
    public AppUserResponseDTO Authenticate(AppUserRequestDTO model);
    public Task Create(AppUser newUser);
}