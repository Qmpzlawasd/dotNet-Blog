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
    // err
    // public async Task<AppUser> GetById(Guid id)
    // {
    //     return _userRepository.SelectUser(id);
    // }
}