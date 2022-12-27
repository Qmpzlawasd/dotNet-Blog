using Blog.Models.Base;

namespace Blog.Models;

public class User : BaseEntity
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? Age { get; set; }
    public string? Sex { get; set; }
}