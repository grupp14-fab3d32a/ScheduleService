namespace ScheduleService.DTOs
{
    public class GymLocationRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string OpeningHours { get; set; } = string.Empty;
        public string MapUrl { get; set; } = string.Empty;
    }
}
