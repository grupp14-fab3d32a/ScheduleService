using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ScheduleContext(DbContextOptions<ScheduleContext> options) : DbContext(options)
{
    public DbSet<WorkoutEntity> Workouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorkoutEntity>().HasData(
            new WorkoutEntity
            {
                Id = Guid.Parse("11111111-1111-1111-3333-111111111111"),
                Title = "Core Blast",
                Description = "Intense core workout",
            },
            new WorkoutEntity
            {
                Id = Guid.Parse("22222222-2222-2222-3333-222222222222"),
                Title = "Yoga Flow"
            },
            new WorkoutEntity
            {
                Id = Guid.Parse("11111111-1111-5555-3333-111111111111"),
                Title = "Zumba",
                Description = "Dance your way to strength and condition",
            },
            new WorkoutEntity
            {
                Id = Guid.Parse("22222222-2222-6666-3333-222222222222"),
                Title = "Circle Gym"
            }
        );
    }
}