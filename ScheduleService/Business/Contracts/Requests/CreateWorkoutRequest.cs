using System.ComponentModel.DataAnnotations;

namespace Business.Contracts.Requests;

public class CreateWorkoutRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = null!;

    [MaxLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
    public string? Description { get; set; }
}
