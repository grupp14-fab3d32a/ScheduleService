using System.Linq.Expressions;
using Data.Entities;

namespace Data.Interfaces;

public interface IWorkoutRepository
{
  Task<WorkoutEntity> CreateAsync(WorkoutEntity entity);
    Task<IEnumerable<WorkoutEntity>> GetAllAsync();
  Task<bool> DeleteAsync(Expression<Func<WorkoutEntity, bool>> expression);
  Task<bool> ExistsAsync(Expression<Func<WorkoutEntity, bool>> expression);
  Task<WorkoutEntity?> UpdateAsync(WorkoutEntity entity);
}
