//using Microsoft.EntityFrameworkCore;
//using QLDRL.Data;
//using QLDRL.DTOs.EvidenceDTOs;
//using QLDRL.Models;
//using QLDRL.DTOs.Mappers;

//namespace QLDRL.Services
//{
//    public class EvidenceService
//    {
//        private readonly AppDbContext _context;

//        public EvidenceService(AppDbContext context)
//        {
//            _context = context;
//        }

//        // Lấy tất cả evidence
//        public async Task<List<Evidence>> GetAll()
//        {
//            return await _context.Evidences
//                .Include(e => e.Event)
//                .Include(e => e.Student)
//                    .ThenInclude(s => s.StudentClass)
//                        .ThenInclude(sc => sc.Major)
//                            .ThenInclude(m => m.Faculty)
//                .ToListAsync();
//        }

//        // Lấy theo Id
//        public async Task<Evidence?> GetById(int id)
//        {
//            return await _context.Evidences
//                .Include(e => e.Event)
//                .Include(e => e.Student)
//                    .ThenInclude(s => s.StudentClass)
//                        .ThenInclude(sc => sc.Major)
//                            .ThenInclude(m => m.Faculty)
//                .FirstOrDefaultAsync(e => e.Id == id);
//        }

//        // Tạo evidence mới
//        public async Task<ValidateEvidenceResult> Create(CreateEvidenceDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Title))
//                return ValidateEvidenceResult.EmptyTitle;

//            if (string.IsNullOrWhiteSpace(dto.ImagePath))
//                return ValidateEvidenceResult.EmptyImagePath;

//            if (!await _context.Events.AnyAsync(ev => ev.Id == dto.EventId))
//                return ValidateEvidenceResult.InvalidEvent;

//            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
//                return ValidateEvidenceResult.InvalidStudent;

//            Evidence evd = EvidenceMapper.ToEvidence(dto);
//            await _context.Evidences.AddAsync(evd);
//            await _context.SaveChangesAsync();
//            return ValidateEvidenceResult.Success;
//        }

//        // Cập nhật evidence
//        public async Task<ValidateEvidenceResult> Update(Evidence evd, UpdateEvidenceDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Title))
//                return ValidateEvidenceResult.EmptyTitle;

//            if (string.IsNullOrWhiteSpace(dto.ImagePath))
//                return ValidateEvidenceResult.EmptyImagePath;

//            if (!await _context.Events.AnyAsync(ev => ev.Id == dto.EventId))
//                return ValidateEvidenceResult.InvalidEvent;

//            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
//                return ValidateEvidenceResult.InvalidStudent;

//            EvidenceMapper.MapUpdate(evd, dto);
//            await _context.SaveChangesAsync();
//            return ValidateEvidenceResult.Success;
//        }

//        // Xóa evidence
//        public async Task Delete(Evidence evd)
//        {
//            _context.Evidences.Remove(evd);
//            await _context.SaveChangesAsync();
//        }
//    }

//    public enum ValidateEvidenceResult
//    {
//        Success,
//        EmptyTitle,
//        EmptyImagePath,
//        InvalidEvent,
//        InvalidStudent
//    }
//}