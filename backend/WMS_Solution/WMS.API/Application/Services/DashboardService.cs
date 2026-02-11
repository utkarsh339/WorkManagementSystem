using Microsoft.EntityFrameworkCore;
using WMS.API.Application.DTOs.Dashboard;
using WMS.API.Application.Interfaces;
using TaskStatus = WMS.API.Domain.Enums.TaskStatus;
using WMS.API.Infrastructure.Data;

namespace WMS.API.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _db;

        public DashboardService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AdminDashboardDto> GetAdminDashboardAsync()
        {
            return new AdminDashboardDto
            {
                TotalUsers = await _db.Users.CountAsync(),
                ActiveUsers = await _db.Users.CountAsync(u => u.IsActive),
                TotalTasks = await _db.Tasks.CountAsync(),
                CompletedTasks = await _db.Tasks.CountAsync(t => t.Status == TaskStatus.Done)
            };
        }

        public async Task<ManagerDashboardDto> GetManagerDashboardAsync(Guid managerId)
        {
            var tasks = _db.Tasks.Where(t => t.CreatedByUserId == managerId);

            return new ManagerDashboardDto
            {
                TasksCreatedByMe = await tasks.CountAsync(),
                PendingTasks = await tasks.CountAsync(t=> t.Status == TaskStatus.Todo),
                InProgressTasks = await tasks.CountAsync(t=> t.Status == TaskStatus.InProgress),
                OverdueTasks = await tasks.CountAsync(
                    t=> t.DueDate < DateTime.UtcNow && t.Status != TaskStatus.Done
                )
            };
        }

        public async Task<EmployeeDashboardDto> GetEmployeeDashboardAsync(Guid employeeId)
        {
            var tasks = _db.Tasks.Where(t => t.AssignedToUserId == employeeId);

            return new EmployeeDashboardDto
            {
                MyTotalTasks = await tasks.CountAsync(),
                CompletedTasks = await tasks.CountAsync(t => t.Status == TaskStatus.Done),
                PendingTasks = await tasks.CountAsync(t => t.Status != TaskStatus.Done)
            };
        }
    }
}
