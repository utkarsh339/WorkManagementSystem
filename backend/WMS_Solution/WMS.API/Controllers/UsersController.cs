using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMS.API.Application.DTOs.Users;
using WMS.API.Application.Interfaces;

namespace WMS.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles="Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpPut("{id}/role")]
        public async Task<IActionResult> UpdateRole(Guid id, UpdateUserRoleDto dto)
        {
            await _userService.UpdateUserRoleAsync(id, dto);
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, UpdateUserStatusDto dto)
        {
            await _userService.UpdateUserStatusAsync(id, dto);
            return NoContent();
        }
    }
}
