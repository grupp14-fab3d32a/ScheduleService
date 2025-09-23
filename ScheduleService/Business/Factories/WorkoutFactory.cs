using Business.Contracts.Requests;
using Business.Contracts.Responses;
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
  public static WorkoutEntity Update(UpdateWorkoutRequest request) => new()
  {
    Id = request.Id,
    Title = request.Title ?? string.Empty,
    Description = request.Description,
  };
  public static WorkoutResponse ToWorkoutResponse(WorkoutEntity entity) => new()
  {
    Id = entity.Id.ToString(),
    Title = entity.Title,
    Description = entity.Description
  };
}
