using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WMS.API.Application.Interfaces;

namespace WMS.API.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public async Task<IActionResult> Admin()
        {
            return Ok(await _dashboardService.GetAdminDashboardAsync());
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("manager")]
        public async Task<IActionResult> Manager()
        {
            return Ok(await _dashboardService.GetManagerDashboardAsync(GetUserId()));
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("employee")]
        public async Task<IActionResult> Employee()
        {
            return Ok(await _dashboardService.GetEmployeeDashboardAsync(GetUserId()));
        }
    }
}
