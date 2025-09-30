using Business.Contracts.Responses;
using Data.Entities;

namespace Business.Mappings;

public static class WorkoutMapper
{
    public static WorkoutResponse ToWorkoutResponse(WorkoutEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        Date = entity.Date,
        StartTime = entity.StartTime,
        Instructor = entity.Instructor,
        Location = entity.Location,
        TotalSpots = entity.TotalSpots,
        BookedSpots = entity.BookedSpots
    };
}
