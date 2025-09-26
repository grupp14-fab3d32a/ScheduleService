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
      TotalSpots = request.TotalSpots,
      BookedSpots = 0
    };
  }

  public static WorkoutEntity Update(WorkoutEntity existing, UpdateWorkoutRequest request)
  {
    existing.Title = request.Title ?? existing.Title;
    existing.Description = request.Description ?? existing.Description;
    existing.TotalSpots = request.TotalSpots ?? existing.TotalSpots;
    existing.BookedSpots = request.BookedSpots ?? existing.BookedSpots;

    return existing;
  }
}
