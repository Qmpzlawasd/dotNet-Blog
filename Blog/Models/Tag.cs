using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Models.Base;

namespace Blog.Models;

public class Tag
{
    public Guid BlogPostId { get; set; }
    public Guid CategoryId { get; set; }
    public virtual BlogPost BlogPost { get; set; }
    public virtual Category Category { get; set; }
}