using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.Models;
using QLDRL.Enums;
using QLDRL.DTOs.AppealDTOs;

namespace QLDRL.Services
{
    public class AppealService
    {
        private readonly AppDbContext _context;

        public AppealService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appeal>> GetAll()
        {
            return await _context.Appeals
                .Include(a => a.Event)
                .Include(a => a.Student)
                    .ThenInclude(s => s.User)
                .Include(a => a.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .Include(a => a.Manager)
                .ToListAsync();
        }

        public async Task<Appeal?> GetById(int id)
        {
            return await _context.Appeals
                .Include(a => a.Event)
                .Include(a => a.Student)
                    .ThenInclude(s => s.User)
                .Include(a => a.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .Include(a => a.Manager)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Appeal?> GetByStudentEvent(int studenUserId, int eventId)
        {
            return await _context.Appeals
                .Include(a => a.Event)
                .Include(a => a.Student)
                    .ThenInclude(s => s.User)
                .Include(a => a.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .Include(a => a.Manager)
                .FirstOrDefaultAsync(a => a.StudentUserId == studenUserId && a.EventId == eventId);
        }

        public async Task<ValidateAppealResult> ValidateAppeal(Appeal appeal)
        {
            if (string.IsNullOrWhiteSpace(appeal.Content))
                return ValidateAppealResult.EmptyContent;

            if (string.IsNullOrWhiteSpace(appeal.ImagePath))
                return ValidateAppealResult.EmptyImagePath;

            if (!await _context.Events.AnyAsync(ev => ev.Id == appeal.EventId))
                return ValidateAppealResult.InvalidEvent;

            if (!await _context.Students.AnyAsync(s => s.UserId == appeal.StudentUserId))
                return ValidateAppealResult.InvalidStudent;

            return ValidateAppealResult.Success;
        }

        public async Task<int> Create(Appeal appeal)
        {
            await _context.Appeals.AddAsync(appeal);
            await _context.SaveChangesAsync();
            return appeal.Id;
        }

        public async Task Update(Appeal appeal, UpdateAppealDTO appealDTO)
        {
            appeal.ManagerUserId = appealDTO.ManagerUserId;
            appeal.Status = appealDTO.Status;
            appeal.Response = appealDTO.Response;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Appeal appeal)
        {
            _context.Appeals.Remove(appeal);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatus(Appeal appeal, AppealStatus status)
        {
            appeal.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}