using Blog.Models;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.AppUserRepository;

public interface IAppUserRepository : IGenericRepository<AppUser>
{
    public AppUser FindByUsername(string name);
}