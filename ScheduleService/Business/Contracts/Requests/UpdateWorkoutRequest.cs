using System.ComponentModel.DataAnnotations;

namespace Business.Contracts.Requests;
public class UpdateWorkoutRequest
{
    [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string? Title { get; set; }

    [MaxLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
    public string? Description { get; set; }

    public TimeOnly? StartTime { get; set; }
    public DateOnly? Date { get; set; }
    [MaxLength(100, ErrorMessage = "Instructor name cannot exceed 100 characters.")]
    public string? Instructor { get; set; }

    [MaxLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
    public string? Location { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "TotalSpots must be a positive number.")]
    public int? TotalSpots { get; set; }
}
/// BookedSpots is managed via bookings, not manually updated here