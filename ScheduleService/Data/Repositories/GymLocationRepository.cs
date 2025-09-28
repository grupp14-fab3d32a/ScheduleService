using Data.Entities;
using Data.Interfaces;
using ScheduleService.Data.Entities;
using ScheduleService.Data.Interfaces;
namespace ScheduleService.Data.Repositories
{
    public class GymLocationRepository : IGymLocationRepository
    {
        private readonly List<GymLocation> _gyms = new()
        {
            new GymLocation { Name = "Core Gym Club Stockholm", Address = "Sveavägen 12", City = "Stockholm" },
            new GymLocation { Name = "Core Gym Club Göteborg", Address = "Avenyn 5", City = "Göteborg" },
            new GymLocation { Name = "Core Gym Club Malmö", Address = "Drottningatan 30", City = "Malmö" },
            new GymLocation { Name = "Core Gym Club Uppsala", Address = "Nynäsvägen 80", City = "Uppsala" }
        };

        public IEnumerable<GymLocation> GetAll() => _gyms;
    }
}