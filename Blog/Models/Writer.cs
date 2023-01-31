using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Models;

public class Writer
{
    [Key]
    public Guid UserId { get; set; }
    [JsonIgnore]
    public virtual AppUser AppUser { get; set; }
    
    public int BlogPostsWritten { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual ICollection<BlogPost>? BlogPosts { get; set; }
}