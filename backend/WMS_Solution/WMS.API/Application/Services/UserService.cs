using Microsoft.EntityFrameworkCore;
using WMS.API.Application.DTOs.Users;
using WMS.API.Application.Interfaces;
using WMS.API.Infrastructure.Data;

namespace WMS.API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            return await _db.Users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = u.Role,
                    IsActive = u.IsActive,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }

        public async Task UpdateUserRoleAsync(Guid userId, UpdateUserRoleDto dto)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            user.Role = dto.Role;
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUserStatusAsync(Guid userId, UpdateUserStatusDto dto)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            user.IsActive = dto.IsActive;
            await _db.SaveChangesAsync();
        }
    }
}
