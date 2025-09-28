using Data.Entities;
using ScheduleService.Data.Entities;

namespace ScheduleService.Data.Interfaces
{
    public interface IGymLocationRepository
    {
        IEnumerable<GymLocation> GetAll();
    }
}
