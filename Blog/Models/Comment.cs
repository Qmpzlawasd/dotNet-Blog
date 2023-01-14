using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models;

using Blog.Models.Base;

public class Comment 
{
    public Guid UserId { get; set; }
    public Guid BlogPostId { get; set; }
    public virtual User User { get; set; }
    public virtual BlogPost BlogPost { get; set; }
    // attr
    public string Text { get; set; }
    public int  LikeCount { get; set; }
    public DateTime DatePosted { get; set; }
}