using System.ComponentModel.DataAnnotations;

namespace Blog.Models.DTOs;

public class AppUserResponseDTO
{
    public string Username { get; set; }
    [Required]
    public string Password{ get; set; }
    [Required]
    public string Token{ get; set; }

}