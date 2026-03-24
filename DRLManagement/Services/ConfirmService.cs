//using Microsoft.EntityFrameworkCore;
//using QLDRL.Data;
//using QLDRL.DTOs.ConfirmDTOs;
//using QLDRL.Models;

//namespace QLDRL.Services
//{
//    public class ConfirmService
//    {
//        private readonly AppDbContext _context;

//        public ConfirmService(AppDbContext context)
//        {
//            _context = context;
//        }

//        // Lấy tất cả confirm
//        public async Task<List<Confirm>> GetAll()
//        {
//            return await _context.Confirms
//                .Include(c => c.Semester)
//                .Include(c => c.Student)
//                    .ThenInclude(s => s.StudentClass)
//                        .ThenInclude(sc => sc.Major)
//                            .ThenInclude(m => m.Faculty)
//                .Include(c => c.Manager)
//                .ToListAsync();
//        }

//        // Lấy theo Id
//        public async Task<Confirm?> GetById(int id)
//        {
//            return await _context.Confirms
//                .Include(c => c.Semester)
//                .Include(c => c.Student)
//                    .ThenInclude(s => s.StudentClass)
//                        .ThenInclude(sc => sc.Major)
//                            .ThenInclude(m => m.Faculty)
//                .Include(c => c.Manager)
//                .FirstOrDefaultAsync(c => c.Id == id);
//        }

//        // Tạo confirm mới
//        public async Task<ValidateConfirmResult> Create(CreateConfirmDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Reason))
//                return ValidateConfirmResult.EmptyReason;

//            if (!await _context.Semesters.AnyAsync(s => s.Id == dto.SemesterId))
//                return ValidateConfirmResult.InvalidSemester;

//            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
//                return ValidateConfirmResult.InvalidStudent;

//            Confirm confirm = new Confirm
//            {
//                Reason = dto.Reason,
//                SemesterId = dto.SemesterId,
//                StudentUserId = dto.StudentUserId,
//                ManagerUserId = dto.ManagerUserId
//            };

//            await _context.Confirms.AddAsync(confirm);
//            await _context.SaveChangesAsync();
//            return ValidateConfirmResult.Success;
//        }

//        // Cập nhật confirm (manager chỉnh sửa)
//        public async Task<ValidateConfirmResult> Update(Confirm confirm, UpdateConfirmDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Reason))
//                return ValidateConfirmResult.EmptyReason;

//            if (!await _context.Semesters.AnyAsync(s => s.Id == dto.SemesterId))
//                return ValidateConfirmResult.InvalidSemester;

//            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
//                return ValidateConfirmResult.InvalidStudent;

//            confirm.Reason = dto.Reason;
//            confirm.SemesterId = dto.SemesterId;
//            confirm.StudentUserId = dto.StudentUserId;
//            confirm.ManagerUserId = dto.ManagerUserId;

//            await _context.SaveChangesAsync();
//            return ValidateConfirmResult.Success;
//        }

//        // Xóa confirm
//        public async Task Delete(Confirm confirm)
//        {
//            _context.Confirms.Remove(confirm);
//            await _context.SaveChangesAsync();
//        }
//    }

//    public enum ValidateConfirmResult
//    {
//        Success,
//        EmptyReason,
//        InvalidSemester,
//        InvalidStudent
//    }
//}