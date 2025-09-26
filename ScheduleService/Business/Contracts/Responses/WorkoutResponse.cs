namespace Business.Contracts.Responses;

public class WorkoutResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}
