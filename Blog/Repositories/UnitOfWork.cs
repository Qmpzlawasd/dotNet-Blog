using Blog.Data;
using Blog.Repositories.AppUserRepository;
using Blog.Repositories.BlogPostRepository;
using Blog.Repositories.CategoryRepository;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public interface IUnitOfWork
{
    Task<bool> SaveAsync();
    IAppUserRepository AppUserRepository { get; }
    IBlogPostRepository BlogPostRepository { get; }
    ICategoryRepository CategoryRepository { get; }
}

public class UnitOfWork : IUnitOfWork
{
    public IAppUserRepository AppUserRepository { get; set; }
    public IBlogPostRepository BlogPostRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; set; }
    private BlogContext Dbcontext { get; set; }

    public UnitOfWork(IAppUserRepository appUserRepository, IBlogPostRepository blogPostRepository,
        ICategoryRepository categoryRepository, BlogContext dbcontext)
    {
        AppUserRepository = appUserRepository;
        BlogPostRepository = blogPostRepository;
        CategoryRepository = categoryRepository;
        Dbcontext = dbcontext;
    }

    public async Task<bool> SaveAsync()
    {
        try
        {
            return await Dbcontext.SaveChangesAsync() > 0;
        }
        catch (SqlException e)
        {
            Console.WriteLine("Sql Error");
            Console.WriteLine(e);
        }

        return false;
    }
}