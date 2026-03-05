using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;

namespace QLDRL.Services
{
    public class UserService
    {
        private readonly RoleServices _roleServices;
        private readonly AppDbContext _context;
        public UserService(AppDbContext context, RoleServices roleServices)
        {
            _context = context;
            _roleServices = roleServices;
        }
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
            var roles = new List<Role>();
            foreach (var roleId in createUserDTO.RoleIds)
            {
                var role = await _roleServices.GetById(roleId);
                if(role != null)
                {
                    roles.Add(role);
                }
            }
            user.Roles = roles;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task Update(User user, CreateUpdateUserDTO updateUserDTO)
        {
            UserMapper.MapUpdate(user, updateUserDTO);

            var roleIds = updateUserDTO.RoleIds;
            var roles = new List<Role>();
            foreach(var roleId in roleIds)
            {
                var role = await _roleServices.GetById(roleId);
                if(role != null)
                {
                    roles.Add(role);
                }
            }
            var oldRoles = user.Roles.Where(x => !roleIds.Contains(x.Id)).ToList();
            foreach(var role in oldRoles)
            {
                user.Roles.Remove(role);
            }
            var newRoles = roles.Where(r => !user.Roles.Any(ur => ur.Id == r.Id)).ToList();
            foreach(var role in newRoles)
            {
                user.Roles.Add(role);
            }
            await _context.SaveChangesAsync();
        }
        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
