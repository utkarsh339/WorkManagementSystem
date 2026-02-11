using WMS.API.Domain.Enums;

namespace WMS.API.Application.DTOs.Users
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
