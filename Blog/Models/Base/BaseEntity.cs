using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models.Base;

public class BaseEntity : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now.ToUniversalTime();
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? DateDeleted { get; set; }
}