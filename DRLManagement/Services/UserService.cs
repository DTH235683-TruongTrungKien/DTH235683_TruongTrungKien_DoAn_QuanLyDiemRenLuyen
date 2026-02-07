using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;
using QLDRL.Helpers;

namespace QLDRL.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        //CRUD
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User?> GetByUserEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task Create(CreateUpdateUserDTO createUserDTO)
        {
            User user = UserMapper.ToUser(createUserDTO);
            user.UserRoles = createUserDTO.RoleIds.Select(roleId => new UserRole
            {
                RoleId = roleId,
            }).ToList();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task Update(User user, CreateUpdateUserDTO updateUserDTO)
        {
            UserMapper.MapUpdate(user, updateUserDTO);
            
            var newRoleIds = updateUserDTO.RoleIds;

            _context.UserRoles.RemoveRange(user.UserRoles.Where(x => !newRoleIds.Contains(x.RoleId)).ToList());
            _context.UserRoles.AddRange(newRoleIds
                .Except(user.UserRoles.Select(x => x.RoleId))
                .Select(roleId => new UserRole
                {
                    RoleId = roleId,
                })
            );
            await _context.SaveChangesAsync();
        }
        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        //Auth
        public async Task
        public async Task<UserDTO?> Login(string email, string password)
        {
            var user = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null || !Utils.VerifyPassword(password, user.HashedPassword))
            {
                return null;
            }
            return UserMapper.ToUserDTO(user);
        }
    }
}
