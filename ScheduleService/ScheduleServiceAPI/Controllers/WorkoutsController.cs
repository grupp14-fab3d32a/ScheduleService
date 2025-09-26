using Business.Contracts.Requests;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleServiceAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkoutsController(IWorkoutService workoutService) : ControllerBase
{
  private readonly IWorkoutService _workoutService = workoutService;

    #region Create
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateWorkoutRequest request)
    {
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

        try
        {
            var result = await _workoutService.CreateWorkoutAsync(request);
            return Ok(new { success = true, workout = result });
        }
        catch (Exception)
        {
            return StatusCode(500, new { success = false, message = "Workout could not be created." });
        }
    }
    #endregion

    #region Read
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    
    {
        var result = await _workoutService.GetAllWorkoutsAsync();
        return Ok(result);
    }
    #endregion

    #region Delete
    [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAsync(Guid id)
  {
    try
    {
      var deleted = await _workoutService.DeleteWorkoutAsync(id);

      if (!deleted)
        return NotFound(new { success = false, message = "Workout not found." });

        return Ok(new { success = true});
    }
    catch (Exception)
    {
        return StatusCode(500, new { success = false, message = "Server error." });
    }
  }
  #endregion

    #region Update (Admin)
    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateWorkoutRequest update)
    {
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var result = await _workoutService.UpdateAsync(update);
    if (result == null)
        return NotFound(new { success = false, message = "Workout not found or could not be updated." });

    return Ok(new { success = true, data = result });
    }
    #endregion
}
