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

    public BlogPost? FindByTitle(string title)
    {
        return _table.FirstOrDefault(x => x.Title == title);
    }

    public List<string> GetTags(Guid postId)
    {
        var query = _context.BlogPosts.Where(x => x.Id == postId).Join(_context.Tags, post =>
            post.Id, tag => tag.BlogPostId, (post, tag) => new { post, tag }).Select(obj => obj.tag.Category.Name);
        return query.ToList();
    }

    public List<BestBlogPostsDTO> GetTopPostsByLikes()
    {
        var query = from post in _context.BlogPosts
            join like in _context.Likes on post.Id equals like.BlogPostId
            group like by like.BlogPostId
            into g
            select new BestBlogPostsDTO { Id = g.Key, Likes = g.Count() };
        var list = query.OrderBy(x => x.Likes).ToList();
        return list;
    }
}