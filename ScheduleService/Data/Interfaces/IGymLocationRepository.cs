using Data.Entities;

namespace ScheduleService.Data.Interfaces
{
    public interface IGymLocationRepository
    {
        IEnumerable<GymLocationEntity> GetAll();
    }
}
