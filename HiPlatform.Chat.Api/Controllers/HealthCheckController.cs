using Microsoft.AspNetCore.Mvc;

namespace HiPlatform.Chat.Api.Controllers
{
    [Route("1.0/api/healthcheck")]
    public class HealthCheckController : Controller
    {
        public IActionResult Get() => Ok();
    }
}
