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

    public async Task<bool> ExistsAsync(Expression<Func<WorkoutEntity,bool>> expression)
    {
        return expression == null ? throw new ArgumentNullException(nameof(expression)) : await _table.AnyAsync(expression);
    }
}
