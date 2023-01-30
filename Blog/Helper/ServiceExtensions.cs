using Blog.Migrations.JwtToken;
using Blog.Repositories;
using Blog.Repositories.AppUserRepository;
using Blog.Repositories.BlogPostRepository;
using Blog.Repositories.CategoryRepository;
using Blog.Services.BlogPost;
using Blog.Services.Tag;
using Blog.Services.User;

namespace Blog.Helper;

public static class ServiceExtensions

{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAppUserRepository, AppUserRepository>();
        services.AddScoped<IBlogPostRepository, BlogPostRepositoy>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBlogPostService, BlogPostService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITagService, TagService>();
        return services;
    }

    public static IServiceCollection AddUtility(this IServiceCollection services)
    {
        services.AddScoped<IJwtUtils, JwtUtils>();

        return services;
    }
}