using WMS.API.Domain.Enums;

namespace WMS.API.Application.DTOs.Auth
{
    public class RegisterRequestDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public UserRole Role { get; set; }
    }
}
