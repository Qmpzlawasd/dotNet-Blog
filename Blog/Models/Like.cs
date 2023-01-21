using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models.Base;

namespace Blog.Models;

public class Like
{
    public Guid BlogPostId { get; set; }
    public Guid UserId { get; set; }

    public virtual BlogPost BlogPost { get; set; }
    public virtual AppUser AppUser { get; set; }
}