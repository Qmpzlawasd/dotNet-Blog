using Blog.Models.Base;

namespace Blog.Models;

public class BlogPost : BaseEntity
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    
    public virtual Writer Writer{ get; set; }
    public  Guid WriterId{ get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Tag>? Tags { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }



}