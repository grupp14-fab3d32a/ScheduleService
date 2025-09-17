using Business.Contracts.Requests;
using Business.Contracts.Responses;

namespace Business.Interfaces;

public interface IWorkoutService
{
    Task<bool> CreateWorkoutAsync(CreateWorkoutRequest request);
}
