namespace Business.Contracts.Responses;

public class WorkoutResponse
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}
