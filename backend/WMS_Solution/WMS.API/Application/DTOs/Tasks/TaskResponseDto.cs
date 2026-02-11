using TaskStatus = WMS.API.Domain.Enums.TaskStatus;
using TaskPriority = WMS.API.Domain.Enums.TaskPriority;

namespace WMS.API.Application.DTOs.Tasks
{
    public class TaskResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }

        public string AssignedTo { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
