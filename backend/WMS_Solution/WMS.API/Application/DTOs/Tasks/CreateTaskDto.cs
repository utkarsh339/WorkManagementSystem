using WMS.API.Domain.Enums;

namespace WMS.API.Application.DTOs.Tasks
{
    public class CreateTaskDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid AssignedToUserId { get; set; }
    }
}
