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
        Description = request.Description ?? string.Empty,
        Date = request.Date,
        StartTime = request.StartTime,
        Instructor = request.Instructor ?? string.Empty,
        Location = request.Location ?? string.Empty,
        TotalSpots = request.TotalSpots,
        BookedSpots = 0
    };
  }

  public static WorkoutEntity Update(WorkoutEntity existing, UpdateWorkoutRequest request)
  {
        existing.Title = request.Title ?? existing.Title;
        existing.Description = request.Description ?? existing.Description;
        existing.Date = request.Date ?? existing.Date;
        existing.StartTime = request.StartTime ?? existing.StartTime;
        existing.Instructor = request.Instructor ?? existing.Instructor;
        existing.Location = request.Location ?? existing.Location;
        existing.TotalSpots = request.TotalSpots ?? existing.TotalSpots;

    return existing;
  }
}
