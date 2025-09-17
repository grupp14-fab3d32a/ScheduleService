using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ScheduleContext(DbContextOptions<ScheduleContext> options) : DbContext(options)
{
    public DbSet<WorkoutEntity> WorkoutEntities { get; set; }

}
