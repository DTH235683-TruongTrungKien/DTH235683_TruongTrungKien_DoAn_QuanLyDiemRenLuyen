using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Helpers;

namespace QLDRL.Services
{
    public class AuthServices
    {
        private readonly AppDbContext _context;
        public AuthServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<UserDTO?> Login(string email, string password)
        {
            var user = await _context.Users
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user == null || !Utils.VerifyPassword(password, user.HashedPassword))
            {
                return null;
            }
            return UserMapper.ToUserDTO(user);
        }
    }
}
