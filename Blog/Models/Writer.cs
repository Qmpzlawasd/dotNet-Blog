using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models.Base;

namespace Blog.Models;

public class Writer
{
    [Key]
    public Guid UserId { get; set; }
    
    public int BlogPostsWritten { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<BlogPost>? BlogPosts { get; set; }
}