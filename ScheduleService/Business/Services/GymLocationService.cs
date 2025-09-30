using Data.Entities;
using Data.Interfaces;
using ScheduleService.Data.Entities;
using ScheduleService.Data.Interfaces;

namespace ScheduleService.Business.Services
{
    public class GymLocationService
    {
        private readonly IGymLocationRepository _repo;

        public GymLocationService(IGymLocationRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<GymLocation> GetAll() => _repo.GetAll();
    }
}
