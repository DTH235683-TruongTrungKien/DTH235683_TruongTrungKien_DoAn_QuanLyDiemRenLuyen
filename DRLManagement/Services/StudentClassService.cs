using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.Models;

namespace QLDRL.Services
{
    public class StudentClassService
    {
        private readonly AppDbContext _context;

        public StudentClassService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<StudentClass>> GetAll()
        {
            return await _context.StudentClasses
                .Include(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .ToListAsync();
        }

        public async Task<StudentClass?> GetById(int id)
        {
            return await _context.StudentClasses
                .Include(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StudentClass?> GetByClassName(string className)
        {
            return await _context.StudentClasses
                .Include(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.Name == className);
        }
    }
}