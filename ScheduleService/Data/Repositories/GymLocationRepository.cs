using Data.Entities;
using Data.Interfaces;
using ScheduleService.Data.Interfaces;
namespace ScheduleService.Data.Repositories
{
    public class GymLocationRepository : IGymLocationRepository
    {
        private readonly List<GymLocationEntity> _gyms = new()
        {
            new GymLocationEntity { Name = "Core Gym Club Stockholm", Address = "Sveavägen 12", City = "Stockholm" },
            new GymLocationEntity { Name = "Core Gym Club Göteborg", Address = "Avenyn 5", City = "Göteborg" },
            new GymLocationEntity { Name = "Core Gym Club Malmö", Address = "Drottningatan 30", City = "Malmö" },
            new GymLocationEntity { Name = "Core Gym Club Uppsala", Address = "Nynäsvägen 80", City = "Uppsala" }
        };

        public IEnumerable<GymLocationEntity> GetAll() => _gyms;
    }
}