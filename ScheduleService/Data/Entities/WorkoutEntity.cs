using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class WorkoutEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [MaxLength(2000)]
    public string? Description { get; set; }

}
