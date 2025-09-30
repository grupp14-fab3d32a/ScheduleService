namespace Business.Contracts.Responses;

public class WorkoutResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public string? Instructor { get; set; }
    public string? Location { get; set; }
    public int TotalSpots { get; set; }
    public int BookedSpots { get; set; }
}
