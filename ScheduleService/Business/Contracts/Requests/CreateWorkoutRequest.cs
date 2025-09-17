namespace Business.Contracts.Requests;

public class CreateWorkoutRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}
