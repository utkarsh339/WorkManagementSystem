using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WMS.API.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController: ControllerBase
    {
        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            return Ok("You are authorized");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Admin access granted");
        }

    }
}
