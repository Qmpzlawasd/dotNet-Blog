using Blog.Data;
using Blog.Models;

namespace Blog.Repositories.AppUserRepository;

public class AppUserRepository :IAppUserRepository
{
    public AppUserRepository(BlogContext context) : base(context)
    {
            
    }
    
    public AppUser GetUserWithInclude(Guid id)
    {
        // return _table;
    }

}