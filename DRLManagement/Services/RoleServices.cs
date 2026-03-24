using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
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

    }
}