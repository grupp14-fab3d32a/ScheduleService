using System.Diagnostics;
using Business.Contracts.Requests;
using Business.Contracts.Responses;
using Business.Factories;
using Business.Interfaces;
using Business.Mappings;
using Data.Interfaces;

namespace Business.Services;

public class WorkoutService(IWorkoutRepository workoutRepository) : IWorkoutService
{
  private readonly IWorkoutRepository _workoutRepository = workoutRepository;

  #region Create
  public async Task<WorkoutResponse> CreateWorkoutAsync(CreateWorkoutRequest request)
  {
     var entity = WorkoutFactory.Create(request);
     await _workoutRepository.CreateAsync(entity);

     return WorkoutMapper.ToWorkoutResponse(entity);
  }
    #endregion

    #region Read
    public async Task<IEnumerable<WorkoutResponse>> GetAllWorkoutsAsync()
    {
        var entities = await _workoutRepository.GetAllAsync();
        return entities.Select(WorkoutMapper.ToWorkoutResponse).ToList();
    }

    public async Task<WorkoutResponse?> GetWorkoutByIdAsync(Guid id)
    {
      var entity = await _workoutRepository.GetByIdAsync(id);
      if (entity == null)
        return null;

      return WorkoutMapper.ToWorkoutResponse(entity);
    }
    #endregion

    #region Delete
    public async Task<bool> DeleteWorkoutAsync(Guid id)
  {
     var deleted = await _workoutRepository.DeleteAsync(x => x.Id == id);

     return deleted;
    }
  #endregion

  #region Update
  public async Task<WorkoutResponse?> UpdateAsync(Guid id, UpdateWorkoutRequest request)
  {
    var existing = await _workoutRepository.GetByIdAsync(request.Id);

        if (existing == null)
            return null;

    WorkoutFactory.Update(existing, request);
    var updatedEntity = await _workoutRepository.UpdateAsync(existing);

    return updatedEntity == null ? null : WorkoutMapper.ToWorkoutResponse(updatedEntity);
    }
    #endregion

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _workoutRepository.ExistsAsync(x => x.Id == id);
    }

    public async Task<bool?> HasAvailableSpotsAsync(Guid workoutId)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId);
        if (workout == null || workout.TotalSpots == null) return null;

        return (workout.BookedSpots < workout.TotalSpots);
    }

    public async Task<WorkoutResponse?> IncrementBookedSpotsAsync(Guid workoutId)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId);

        if (workout == null || workout.TotalSpots == null) return null;

        if (workout.BookedSpots >= workout.TotalSpots)
            throw new InvalidOperationException("No available spots left.");

        workout.BookedSpots++;

        var updatedEntity = await _workoutRepository.UpdateAsync(workout);
        return updatedEntity == null ? null : WorkoutMapper.ToWorkoutResponse(updatedEntity);
    }

    public async Task<WorkoutResponse?> DecrementBookedSpotsAsync(Guid workoutId)
    {
        var workout = await _workoutRepository.GetByIdAsync(workoutId);

        if (workout == null || workout.TotalSpots == null) return null;

        if (workout.BookedSpots <= 0)
            throw new InvalidOperationException("No bookings to cancel.");

        workout.BookedSpots--;

        var updatedEntity = await _workoutRepository.UpdateAsync(workout);
        return updatedEntity == null ? null : WorkoutMapper.ToWorkoutResponse(updatedEntity);
    }
}
