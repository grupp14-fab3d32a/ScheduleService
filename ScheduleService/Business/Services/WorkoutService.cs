using System.Diagnostics;
using Business.Contracts.Requests;
using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;

namespace Business.Services;

public class WorkoutService(IWorkoutRepository workoutRepository) : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;

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
}
