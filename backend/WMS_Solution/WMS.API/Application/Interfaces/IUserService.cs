using WMS.API.Application.DTOs.Users;

namespace WMS.API.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task UpdateUserRoleAsync(Guid userId, UpdateUserRoleDto dto);
        Task UpdateUserStatusAsync(Guid userId, UpdateUserStatusDto dto);
    }
}
