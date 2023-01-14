using Blog.Models.Base;

namespace Blog.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public bool IsAdmin{ get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Sex { get; set; }
    
    public virtual Writer? Writer{ get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
    
}