using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;

namespace QLDRL.Services
{
    public class EvidenceService
    {
        private readonly AppDbContext _context;

        public EvidenceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evidence>> GetAll()
        {
            return await _context.Evidences
                .Include(e => e.Event)
                .Include(e => e.Student)
                    .ThenInclude(s => s.User)
                .Include(e => e.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .ToListAsync();
        }
        public async Task<List<Evidence>> GetAllInEvent(int eventId)
        {
            return await _context.Evidences
                .Where(e => e.EventId == eventId)
                .Include(e => e.Event)
                .Include(e => e.Student)
                    .ThenInclude(s => s.User)
                .Include(e => e.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .ToListAsync();
        }

        public async Task<Evidence?> GetById(int id)
        {
            return await _context.Evidences
                .Include(e => e.Event)
                .Include(e => e.Student)
                    .ThenInclude(s => s.User)
                .Include(e => e.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Evidence?> GetByStudentEvent(int eventId, int studentUserId)
        {
            return await _context.Evidences
                .Include(e => e.Event)
                .Include(e => e.Student)
                    .ThenInclude(s => s.User)
                .Include(e => e.Student)
                    .ThenInclude(s => s.StudentClass)
                        .ThenInclude(sc => sc.Major)
                            .ThenInclude(m => m.Faculty)
                .FirstOrDefaultAsync(e => e.EventId == eventId && e.StudentUserId == studentUserId);
        }

        public async Task<ValidateEvidenceResult> ValidateEvidence(Evidence dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ImagePath))
                return ValidateEvidenceResult.EmptyImagePath;

            if (!await _context.Events.AnyAsync(ev => ev.Id == dto.EventId))
                return ValidateEvidenceResult.InvalidEvent;

            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
                return ValidateEvidenceResult.InvalidStudent;
            return ValidateEvidenceResult.Success;
        }

        public async Task<int> Create(Evidence dto)
        {
            await _context.Evidences.AddAsync(dto);
            await _context.SaveChangesAsync();
            return dto.Id;
        }

        public async Task Delete(Evidence evd)
        {
            _context.Evidences.Remove(evd);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatus(Evidence evd, EvidenceStatus status)
        {
            evd.Status = status;
            await _context.SaveChangesAsync();
        }

    }
}