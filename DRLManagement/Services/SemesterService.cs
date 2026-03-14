using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.Models;

namespace QLDRL.Services
{
    public class SemesterService
    {
        private readonly AppDbContext _context;

        public SemesterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Semester>> GetAll()
        {
            return await _context.Semesters.ToListAsync();
        }
        public async Task<Semester?> GetById(int id)
        {
            return await _context.Semesters.FindAsync(id);
        }
        public async Task<bool> Any()
        {
            return await _context.Semesters.AnyAsync();
        }

        public async Task<int> Create(Semester semester)
        {
            await _context.Semesters.AddAsync(semester);
            await _context.SaveChangesAsync();
            return semester.Id;
        }
    }
}