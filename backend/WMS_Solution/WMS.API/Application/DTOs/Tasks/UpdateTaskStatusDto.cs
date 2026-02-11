
using TaskStatus = WMS.API.Domain.Enums.TaskStatus;
namespace WMS.API.Application.DTOs.Tasks
{
    public class UpdateTaskStatusDto
    {
        public TaskStatus Status { get; set; }
    }
}
