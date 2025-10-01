using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ScheduleContext(DbContextOptions<ScheduleContext> options) : DbContext(options)
{
    public DbSet<WorkoutEntity> Workouts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WorkoutEntity>().Property(w => w.Date)
            .HasConversion(
                v => v.ToDateTime(TimeOnly.MinValue),
                 v => DateOnly.FromDateTime(v));

        modelBuilder.Entity<WorkoutEntity>().Property(w => w.StartTime)
            .HasConversion(
                v => v.ToTimeSpan(),
                v => TimeOnly.FromTimeSpan(v));


        modelBuilder.Entity<WorkoutEntity>().HasData(
            new WorkoutEntity
            {
                Id = Guid.Parse("11111111-1111-1111-3333-111111111111"),
                Title = "Core Blast",
                Description = "Intense core workout",
                Date = new DateOnly(2025, 10, 5),
                StartTime = new TimeOnly(9, 0),
                Instructor = "Alice Smith",
                Location = "Room A",
                TotalSpots = 20,
                BookedSpots = 5,
            },
            new WorkoutEntity
            {
                Id = Guid.Parse("22222222-2222-2222-3333-222222222222"),
                Title = "Yoga Flow",
                Description = "Relaxing yoga session",
                Date = new DateOnly(2025, 10, 6),
                StartTime = new TimeOnly(11, 0),
                Instructor = "Bob Johnson",
                Location = "Room B",
                TotalSpots = 15,
                BookedSpots = 3,
            },
            new WorkoutEntity
            {
                Id = Guid.Parse("11111111-1111-5555-3333-111111111111"),
                Title = "Zumba",
                Description = "Dance your way to strength and condition",
                Date = new DateOnly(2025, 10, 7),
                StartTime = new TimeOnly(18, 0),
                Instructor = "Carol Davis",
                Location = "Room C",
                TotalSpots = 30,
                BookedSpots = 0,
            },
            new WorkoutEntity
            {
                Id = Guid.Parse("22222222-2222-6666-3333-222222222222"),
                Title = "Circle Gym",
                Description = "Full body workout",
                Date = new DateOnly(2023, 10, 8),
                StartTime = new TimeOnly(17, 0),
                Instructor = "David Wilson",
                Location = "Room A",
                TotalSpots = 25,
                BookedSpots = 10,
            }
        );
    }
}