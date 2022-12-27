using Blog.Models.Base;
namespace Blog.Models;

public class BlogPost: BaseEntity
{
    
    public string? Title{ get; set; }
    public string? Author{ get; set; }
    public string? Text{ get; set; }
    
    
}