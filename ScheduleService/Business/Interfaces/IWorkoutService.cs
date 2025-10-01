using Business.Contracts.Requests;
using Business.Contracts.Responses;

namespace Business.Interfaces;

public interface IWorkoutService
{
    Task<WorkoutResponse> CreateWorkoutAsync(CreateWorkoutRequest request);
    Task<WorkoutResponse?> GetWorkoutByIdAsync(Guid id);
    Task<IEnumerable<WorkoutResponse>> GetAllWorkoutsAsync();
    Task<bool> DeleteWorkoutAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<WorkoutResponse?> UpdateAsync(Guid Id, UpdateWorkoutRequest request);
    Task<bool?> HasAvailableSpotsAsync(Guid workoutId);
    Task<WorkoutResponse?> IncrementBookedSpotsAsync(Guid workoutId);
    Task<WorkoutResponse?> DecrementBookedSpotsAsync(Guid workoutId);
}

