using Blog.Data;
using Blog.Models;
using Blog.Models.DTOs;
using Blog.Repositories.GenericRepository;

namespace Blog.Repositories.BlogPostRepository;

public class BlogPostRepositoy : GenericRepository<BlogPost>, IBlogPostRepository
{
    public BlogPostRepositoy(BlogContext context) : base(context)
    {
        
    }
    public  BlogPost? FindByTitle(string title)
    {
        return _table.FirstOrDefault(x => x.Title == title);
    }

    public List<string> GetTags(Guid postId)
    {
        var query = _context.BlogPosts.Where(x=>x.Id == postId).Join(_context.Tags, post => 
            post.Id, tag => tag.BlogPostId, (post, tag) => new { post, tag }).Select(obj => obj.tag.Category.Name);
        return query.ToList();
        
    }



}