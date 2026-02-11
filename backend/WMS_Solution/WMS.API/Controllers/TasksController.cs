using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WMS.API.Application.DTOs.Tasks;
using WMS.API.Application.Interfaces;

namespace WMS.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Authorize]
    public class TasksController: ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? User.FindFirstValue(ClaimTypes.Name) ?? throw new Exception("User id not found"));
        }

        private string GetRole()
        {
            return User.FindFirstValue(ClaimTypes.Role)!;
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            await _taskService.CreateTaskAsync(dto, GetUserId());
            return Ok();
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTaskDto dto)
        {
            await _taskService.UpdateTaskAsync(id, dto);
            return NoContent();
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }

        [Authorize(Roles = "Employee")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, UpdateTaskStatusDto dto)
        {
            await _taskService.UpdateTaskStatusAsync(id, dto, GetUserId());
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            return Ok(await _taskService.GetTasksAsync(GetUserId(), GetRole()));
        }
    }
}
