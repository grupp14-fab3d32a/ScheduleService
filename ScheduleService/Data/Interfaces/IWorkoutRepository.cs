using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IWorkoutRepository
{
    Task<WorkoutEntity> CreateAsync(WorkoutEntity entity);
    Task<bool> ExistsAsync(Expression<Func<WorkoutEntity, bool>> expression);
}
