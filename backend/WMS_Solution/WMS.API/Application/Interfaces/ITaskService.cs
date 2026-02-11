using WMS.API.Application.DTOs.Tasks;

namespace WMS.API.Application.Interfaces
{
    public interface ITaskService
    {
        Task CreateTaskAsync(CreateTaskDto dto, Guid creatorId);
        Task UpdateTaskAsync(Guid taskId, UpdateTaskDto dto);
        Task DeleteTaskAsync(Guid taskId);
        Task UpdateTaskStatusAsync(Guid taskId, UpdateTaskStatusDto dto, Guid userId);
        Task<List<TaskResponseDto>> GetTasksAsync(Guid userId, string role);
    }
}
