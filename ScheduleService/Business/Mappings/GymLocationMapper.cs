using Business.Contracts.Responses;
using ScheduleService.Data.Entities;

namespace ScheduleService.Mappings
{
    public static class GymLocationMapper
    {
        public static GymLocationResponse ToResponse(GymLocation location)
        {
            return new GymLocationResponse
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                City = location.City,
                OpeningHours = location.OpeningHours,
                MapUrl = location.MapUrl
            };
        }
    }
}
