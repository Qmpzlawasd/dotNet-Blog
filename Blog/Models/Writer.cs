using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class Writer
{
    [Key]
    public Guid UserId { get; set; }
    public virtual AppUser AppUser { get; set; }
    
    public int BlogPostsWritten { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual ICollection<BlogPost>? BlogPosts { get; set; }
}