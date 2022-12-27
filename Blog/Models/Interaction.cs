using Blog.Models.Base;

namespace Blog.Models;

public class Interaction: BaseEntity
{
    public bool Liked{ get; set; }
    public bool Shared{ get; set; }
}