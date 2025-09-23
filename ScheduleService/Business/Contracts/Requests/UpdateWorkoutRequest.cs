using System.ComponentModel.DataAnnotations;

namespace Business.Contracts.Requests;
public class UpdateWorkoutRequest
{
  [Required]
  public Guid Id { get; set; }
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
}
