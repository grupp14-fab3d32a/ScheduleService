using Microsoft.AspNetCore.Mvc;
using ScheduleService.Mappings;
using ScheduleService.Data.Entities;
using Business.Contracts.Requests;

namespace ScheduleService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymLocationController : ControllerBase
    {
        private static readonly List<GymLocation> _locations = new()
        {
            new GymLocation { Name = "Core Gym Club Haninge", Address = "Nynäsvägen 123", City = "Haninge", OpeningHours = "06:00 - 22:00", MapUrl = "https://goo.gl/maps/example" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _locations.Select(l => GymLocationMapper.ToResponse(l));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null) return NotFound();

            return Ok(GymLocationMapper.ToResponse(location));
        }

        [HttpPost]
        public IActionResult Create([FromBody] GymLocationRequest request)
        {
            var newLocation = new GymLocation
            {
                Name = request.Name,
                Address = request.Address,
                City = request.City,
                OpeningHours = request.OpeningHours,
                MapUrl = request.MapUrl
            };

            _locations.Add(newLocation);
            return CreatedAtAction(nameof(GetById), new { id = newLocation.Id }, GymLocationMapper.ToResponse(newLocation));
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] GymLocationRequest request)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null) return NotFound();

            location.Name = request.Name;
            location.Address = request.Address;
            location.City = request.City;
            location.OpeningHours = request.OpeningHours;
            location.MapUrl = request.MapUrl;

            return Ok(GymLocationMapper.ToResponse(location));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null) return NotFound();

            _locations.Remove(location);
            return NoContent();
        }
    }
}
