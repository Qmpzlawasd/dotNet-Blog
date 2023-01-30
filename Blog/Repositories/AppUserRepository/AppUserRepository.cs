using Blog.Data;
using Blog.Models;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.AppUserRepository;

public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository 
{
    public AppUserRepository(BlogContext context) : base(context)
    {

    }

    public AppUser FindByUsername(string name)
    {
        return _context.AppUsers.FirstOrDefault(x => x.Username == name);
    }
}