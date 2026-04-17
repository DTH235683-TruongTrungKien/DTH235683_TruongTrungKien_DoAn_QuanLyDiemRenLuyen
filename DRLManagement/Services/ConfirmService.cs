using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.Enums;
using QLDRL.Models;

namespace QLDRL.Services
{
    public class ConfirmService
    {
        private readonly AppDbContext _context;

        public ConfirmService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Confirm>> GetAll()
        {
            return await _context.Confirms
                .Include(c => c.Semester)
                .Include(c => c.Student)
                    .ThenInclude(s => s.User)
                .Include(c => c.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .Include(c => c.Manager)
                    .ThenInclude(m => m.User)
                .ToListAsync();
        }
        public async Task<List<Confirm>> GetAllByStudent(int studentUserId)
        {
            return await _context.Confirms
                .Where(c => c.StudentUserId == studentUserId)
                .Include(c => c.Semester)
                .ToListAsync();
        }
        public async Task<Confirm?> GetById(int id)
        {
            return await _context.Confirms
                .Include(c => c.Semester)
                .Include(c => c.Student)
                    .ThenInclude(s => s.User)
                .Include(c => c.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .Include(c => c.Manager)
                    .ThenInclude(m => m.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<ValidateConfirmResult> Validate(Confirm confirm)
        {
            if (string.IsNullOrWhiteSpace(confirm.Reason))
                return ValidateConfirmResult.EmptyReason;

            if (!await _context.Semesters.AnyAsync(s => s.Id == confirm.SemesterId))
                return ValidateConfirmResult.InvalidSemester;

            if (!await _context.Students.AnyAsync(s => s.UserId == confirm.StudentUserId))
                return ValidateConfirmResult.InvalidStudent;
            return ValidateConfirmResult.Success;
        }
        public async Task<int> Create(Confirm confirm)
        {
            await _context.Confirms.AddAsync(confirm);
            await _context.SaveChangesAsync();
            return confirm.Id;
        }
        
        public async Task UpdateStatus(Confirm confirm, ConfirmStatus status)
        {
            confirm.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}