using Blog.Models;

namespace Blog.Services.User;

public class UserService
{
    public readonly IAppUserRepository _appUserRepository;
    public readonly IWriterRepository _writerRepository;

    public UserService (IAppUserRepository appUserRepository, IWriterRepository writerRepository)
    {
        _appUserRepository = appUserRepository;
         _writerRepository= writerRepository;
    }
    public async Task<AppUser> GetById(Guid id)
    {
        return _userRepository.SelectUser(id);
    }

}