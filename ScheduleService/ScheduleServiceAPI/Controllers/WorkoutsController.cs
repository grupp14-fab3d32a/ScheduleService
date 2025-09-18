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

    var result = await _workoutService.CreateWorkoutAsync(request);

    if (!result)
      return StatusCode(500, new { success = false, message = "Workout could not be created." });

    return Ok(new { success = true });
  }
  #endregion

  #region Delete
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAsync(string id)
  {
    try
    {
      var result = await _workoutService.DeleteWorkoutAsync(id);

      if (result == true)
        return Ok(new { success = true });

      if (result == false)
        return NotFound(new { success = false, message = "Workout not found." });

      return StatusCode(500, new { success = false, message = "Server error." });

    }
    catch (Exception ex)
    {
      return BadRequest(new { success = false, message = ex.Message });
    }
  }
  #endregion

  #region Update (Admin)
  [HttpPut("update")]
  public async Task<IActionResult> UpdateAsync([FromBody] UpdateWorkoutRequest update)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    if (!await _workoutService.ExistsAsync(update.Id.ToString()))
      return NotFound(new { success = false, message = "Workout not found." });

    var result = await _workoutService.UpdateAsync(update);
    if (result == null)
      return StatusCode(500, new { success = false, message = "Workout could not be updated." });

    return Ok(new { success = true, data = result });
  }
  #endregion
}
