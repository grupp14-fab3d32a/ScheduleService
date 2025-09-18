using System.Diagnostics;
using Business.Contracts.Requests;
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
}
