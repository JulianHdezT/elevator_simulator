using ElevatorApi.Models;
using ElevatorApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ElevatorController : ControllerBase
{
    private readonly ElevatorService _service;

    public ElevatorController(ElevatorService service)
    {
        _service = service;
    }

    [HttpGet("state")]
    public IActionResult GetState()
    {
        var elevator = _service.Elevator;
        return Ok(new
        {
            elevator.CurrentFloor,
            elevator.MovementDirection,
            elevator.DoorsOpen
        });
    }

    [HttpPost("internal-request/{floor}")]
    public IActionResult InternalRequest(int floor)
    {
        _service.Elevator.RequestFloor(floor);
        return Ok();
    }

    [HttpPost("external-call")]
    public IActionResult ExternalCall([FromBody] FloorRequest request)
    {
        _service.Elevator.CallElevator(request.Floor, request.Direction);
        return Ok();
    }

    [HttpPost("step")]
    public IActionResult Step()
    {
        _service.Elevator.Step();
        return Ok();
    }
}