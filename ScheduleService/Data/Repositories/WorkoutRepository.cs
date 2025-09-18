using System.Linq.Expressions;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    protected readonly ScheduleContext _context;
    protected readonly DbSet<WorkoutEntity> _table;

    public WorkoutRepository(ScheduleContext context, DbSet<WorkoutEntity> table)
    {
        _context = context;
        _table = context.Set<WorkoutEntity>();
    }

    #region Create
    public async Task<WorkoutEntity> CreateAsync(WorkoutEntity entity)
    {
        if (entity != null)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        throw new ArgumentNullException(nameof(entity));
    }
    #endregion

    #region Delete
    public async Task<bool> DeleteAsync(Expression<Func<WorkoutEntity, bool>> expression)
    {
        var entityToDelete = await _table.FirstOrDefaultAsync(expression);

        if (entityToDelete != null)
        {
            _table.Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
    #endregion

    public async Task<bool> ExistsAsync(Expression<Func<WorkoutEntity,bool>> expression)
    {
        return expression == null ? throw new ArgumentNullException(nameof(expression)) : await _table.AnyAsync(expression);
    }
}
