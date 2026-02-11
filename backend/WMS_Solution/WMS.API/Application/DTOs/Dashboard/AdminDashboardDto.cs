namespace WMS.API.Application.DTOs.Dashboard
{
    public class AdminDashboardDto
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
    }
}
