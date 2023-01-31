using Blog.Data;
using Blog.Models;
using Blog.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories.AppUserRepository;

public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository 
{
    public AppUserRepository(BlogContext context) : base(context)
    {

    }

    public List<AppUser>  GetWriters()
    {
        return _context.AppUsers.Include(x => x.Writer).Where(x => x.Writer != null).ToList();
    }
    public AppUser? FindByUsername(string name)
    {
        return _context.AppUsers.FirstOrDefault(x => x.Username == name);
    }
}