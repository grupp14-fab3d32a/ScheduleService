using System.ComponentModel.DataAnnotations;

namespace Business.Contracts.Requests;
public class UpdateWorkoutRequest
{
    [Required]
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? TotalSpots { get; set; }
    public int? BookedSpots { get; set; }
}
