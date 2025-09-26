using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
  protected readonly ScheduleContext _context;

  public WorkoutRepository(ScheduleContext context)
  {
    _context = context;
  }

  #region Create
  public async Task<WorkoutEntity> CreateAsync(WorkoutEntity entity)
  {
    if (entity != null)
    {
      await _context.Workouts.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    throw new ArgumentNullException(nameof(entity));
  }
    #endregion

    #region Read
    public async Task<IEnumerable<WorkoutEntity>> GetAllAsync()
    {
        return await _context.Workouts.ToListAsync();
    }
    public async Task<bool> ExistsAsync(Expression<Func<WorkoutEntity, bool>> expression)
    {
        return expression == null ? throw new ArgumentNullException(nameof(expression)) : await _context.Workouts.AnyAsync(expression);
    }

    public async Task<WorkoutEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Workouts.FindAsync(id);
    }
    #endregion

    #region Delete
    public async Task<bool> DeleteAsync(Expression<Func<WorkoutEntity, bool>> expression)
  {
    var entityToDelete = await _context.Workouts.FirstOrDefaultAsync(expression);

    if (entityToDelete != null)
    {
      _context.Workouts.Remove(entityToDelete);
      await _context.SaveChangesAsync();
      return true;
    }

    return false;
  }
  #endregion

  #region Update
  public async Task<WorkoutEntity?> UpdateAsync(WorkoutEntity entity)
  {
    _context.Workouts.Update(entity);
    var updated = await _context.SaveChangesAsync();
    return updated > 0 ? entity : null;
  }
  #endregion
}
