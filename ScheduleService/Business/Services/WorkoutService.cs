using System.Diagnostics;
using Business.Contracts.Requests;
using Business.Contracts.Responses;
using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;

namespace Business.Services;

public class WorkoutService(IWorkoutRepository workoutRepository) : IWorkoutService
{
  private readonly IWorkoutRepository _workoutRepository = workoutRepository;

  #region Create
  public async Task<bool> CreateWorkoutAsync(CreateWorkoutRequest request)
  {
    try
    {
      var entity = WorkoutFactory.Create(request);
      await _workoutRepository.CreateAsync(entity);
      return true;
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error creating workout: {ex.Message}");
      return false;
    }
  }
    #endregion

    #region Read
    public async Task<IEnumerable<WorkoutResponse>> GetAllWorkoutsAsync()
    {
        var entities = await _workoutRepository.GetAllAsync();
        var response = entities.Select(WorkoutFactory.ToWorkoutResponse);
        return response;
    }
    #endregion

    #region Delete
    public async Task<bool?> DeleteWorkoutAsync(string id)
  {
    if (!Guid.TryParse(id, out var guidId))
      throw new ArgumentException("Invalid id", nameof(id));

    try
    {
      return await _workoutRepository.DeleteAsync(x => x.Id == guidId);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error deleting workout: {ex.Message}");
      return null;
    }
  }
  #endregion

  #region Exists
  public async Task<bool> ExistsAsync(string id)
  {
    if (!Guid.TryParse(id, out var guidId))
      throw new ArgumentException("Invalid id", nameof(id));
    return await _workoutRepository.ExistsAsync(x => x.Id == guidId);
  }
  #endregion

  #region Update
  public Task<WorkoutResponse?> UpdateAsync(UpdateWorkoutRequest request)
  {
    try
    {
      var entity = WorkoutFactory.Update(request);
      var response = _workoutRepository.UpdateAsync(entity);
      if (response == null)
        return Task.FromResult<WorkoutResponse?>(null);

      var result = WorkoutFactory.ToWorkoutResponse(response.Result!);
      return Task.FromResult<WorkoutResponse?>(result);
    }
    catch (Exception ex)
    {
      Debug.WriteLine($"Error updating workout: {ex.Message}");
      return Task.FromResult<WorkoutResponse?>(null);
    }
  }
  #endregion
}
