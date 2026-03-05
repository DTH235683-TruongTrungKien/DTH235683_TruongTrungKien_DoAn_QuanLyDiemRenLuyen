using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.RoleDTOs;
using QLDRL.Models;
namespace QLDRL.Services
{
    public class RoleServices
    {
        private readonly AppDbContext _context;

        public RoleServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetById(int id)
        {
            return await _context.Roles.FindAsync(id).AsTask();
        }

        public async Task<Role?> GetByName(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<Role> Create(RoleDTO roleDTO)
        {
            var role = new Role
            {
                Name = roleDTO.Name
            };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async void Update(Role role, RoleDTO roleDTO)
        {
            role.Name = roleDTO.Name;
            await _context.SaveChangesAsync();
        }

        public Task Delete(Role role)
        {
            _context.Roles.Remove(role);
            return _context.SaveChangesAsync();
        }
    }
}