using Business.Contracts.Requests;
using Data.Entities;

namespace Business.Factories;

public static class WorkoutFactory
{
    public static WorkoutEntity Create(CreateWorkoutRequest request)
    {
        return new WorkoutEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
        };
    }
}
