using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WMS.API.Application.DTOs.Tasks;
using WMS.API.Application.Interfaces;
using WMS.API.Domain.Entities;
using WMS.API.Infrastructure.Data;

namespace WMS.API.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _db;

        public TaskService(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateTaskAsync(CreateTaskDto dto, Guid creatorId)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                DueDate = dto.DueDate,
                AssignedToUserId = dto.AssignedToUserId,
                CreatedByUserId = creatorId
            };

            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(Guid taskId, UpdateTaskDto dto)
        {
            var task = await _db.Tasks.FindAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Priority = dto.Priority;
            task.DueDate = dto.DueDate;
            task.AssignedToUserId = dto.AssignedToUserId;

            await _db.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Guid taskId)
        {
            var task = await _db.Tasks.FindAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateTaskStatusAsync(Guid taskId, UpdateTaskStatusDto dto, Guid userId)
        {
            var task = await _db.Tasks.FindAsync(taskId);
            if (task == null)
                throw new Exception("Task not found");

            if (task.AssignedToUserId != userId)
                throw new Exception("You are not assigned to this task");

            task.Status = dto.Status;
            await _db.SaveChangesAsync();
        }

        public async Task<List<TaskResponseDto>> GetTasksAsync(Guid userId, string Role)
        {
            var query = _db.Tasks
                .Include(t => t.AssignedToUser)
                .Include(t => t.CreatedByUser)
                .AsQueryable();

            if(Role == "Employee")
            {
                query = query.Where(t => t.AssignedToUserId == userId);
            }

            return await query.Select(t => new TaskResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                DueDate = t.DueDate,
                AssignedTo = t.AssignedToUser.Name,
                CreatedBy = t.CreatedByUser.Name,
                CreatedAt = t.CreatedAt
            })
            .ToListAsync();
        }
    }
}
