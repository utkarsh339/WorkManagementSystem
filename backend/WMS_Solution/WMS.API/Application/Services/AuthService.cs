using Microsoft.EntityFrameworkCore;
using WMS.API.Application.DTOs.Auth;
using WMS.API.Application.Interfaces;
using WMS.API.Domain.Entities;
using WMS.API.Infrastructure.Auth;
using WMS.API.Infrastructure.Data;

namespace WMS.API.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly AppDbContext _db;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(AppDbContext db, JwtTokenGenerator jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            if (await _db.Users.AnyAsync(u => u.Email == request.Email))
                throw new Exception("Email already exists");

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = request.Role
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = _jwt.GenerateToken(user, out var expiresAt);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !PasswordHasher.verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            if (!user.IsActive)
                throw new Exception("User is inactive");

            var token = _jwt.GenerateToken(user, out var expiresAt);

            return new AuthResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt
            };
        }
    }
}
