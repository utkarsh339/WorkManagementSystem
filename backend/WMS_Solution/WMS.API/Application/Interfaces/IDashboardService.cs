using WMS.API.Application.DTOs.Dashboard;

namespace WMS.API.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<AdminDashboardDto> GetAdminDashboardAsync();
        Task<ManagerDashboardDto> GetManagerDashboardAsync(Guid managerId);
        Task<EmployeeDashboardDto> GetEmployeeDashboardAsync(Guid employeeId);
    }
}
