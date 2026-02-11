using WMS.API.Domain.Enums;
using TaskPriority = WMS.API.Domain.Enums.TaskPriority;
using TaskStatus =  WMS.API.Domain.Enums.TaskStatus;

namespace WMS.API.Domain.Entities
{
    public class TaskItem: BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public TaskStatus Status { get; set; } = TaskStatus.Todo;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;

        public DateTime? DueDate { get; set; } 

        public Guid AssignedToUserId { get; set; }
        public Guid CreatedByUserId { get; set; }

        public User AssignedToUser { get; set; } = null!;
        public User CreatedByUser { get; set; } = null!;
    }
}
