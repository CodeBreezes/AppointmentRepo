using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("GetMyNameJson")]
        public IActionResult GetMyNameJson()
        {
            var result = new { Name = "Sanjay kumar BPST" };
            return Ok(result);
        }
    }
}
