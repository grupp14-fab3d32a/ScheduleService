using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleServiceAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController(IWorkoutService workoutService) : ControllerBase
{
    private readonly IWorkoutService _workoutService = workoutService;

}
