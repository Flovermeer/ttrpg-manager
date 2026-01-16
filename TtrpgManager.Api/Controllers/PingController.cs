using Microsoft.AspNetCore.Mvc;

namespace TtrpgManager.Api.Controllers;

[ApiController]
[Route("api/ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("pong");
    }
}