using Microsoft.AspNetCore.Mvc;
using ScheduleService.Business.Services;

namespace ScheduleServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymLocationsController : ControllerBase
    {
        private readonly GymLocationService _service;

        public GymLocationsController(GymLocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var gyms = _service.GetAll();
            return Ok(gyms);
        }
    }
}
