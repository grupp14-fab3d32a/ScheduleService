namespace ScheduleService.Data.Entities
{
    public class GymLocation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string OpeningHours { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
    }
}
