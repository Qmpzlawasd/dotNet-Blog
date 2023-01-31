namespace Blog.Models.DTOs;

public class BlogPostDTO
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string Language { get; set; }
    public Guid  Writer_id{ get; set; }
}