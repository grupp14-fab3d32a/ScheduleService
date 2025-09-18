using Business.Contracts.Requests;
using Business.Contracts.Responses;

namespace Business.Interfaces;

public interface IWorkoutService
{
  Task<bool> CreateWorkoutAsync(CreateWorkoutRequest request);
  Task<bool?> DeleteWorkoutAsync(string id);
  Task<bool> ExistsAsync(string id);
  Task<WorkoutResponse?> UpdateAsync(UpdateWorkoutRequest request);
}
