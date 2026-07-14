using Microsoft.AspNetCore.Mvc;

namespace NotificationsAPI.Controllers;

[ApiController,Route("api/health")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new{service="NotificationsAPI",status="healthy"});
}
