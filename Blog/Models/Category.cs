using Blog.Models.Base;
namespace Blog.Models;

public class Category: BaseEntity
{
    public string Name{ get; set; }
    public string? Description{ get; set; }
    public virtual ICollection<Tag>? Tags { get; set; }
}