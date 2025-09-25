using Business.Contracts.Responses;
using Data.Entities;

namespace Business.Mappings;

public static class WorkoutMapper
{
    public static WorkoutResponse ToWorkoutResponse(WorkoutEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description
    };
}
