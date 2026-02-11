namespace WMS.API.Application.DTOs.Dashboard
{
    public class ManagerDashboardDto
    {
        public int TasksCreatedByMe { get; set; }
        public int PendingTasks { get; set; }
        public int InProgressTasks { get; set; }
        public int OverdueTasks { get; set; }
    }
}
