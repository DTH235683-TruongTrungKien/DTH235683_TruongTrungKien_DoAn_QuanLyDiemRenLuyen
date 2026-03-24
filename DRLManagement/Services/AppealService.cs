//using Microsoft.EntityFrameworkCore;
//using QLDRL.Data;
//using QLDRL.DTOs.AppealDTOs;
//using QLDRL.Models;

//namespace QLDRL.Services
//{
//    public class AppealService
//    {
//        private readonly AppDbContext _context;

//        public AppealService(AppDbContext context)
//        {
//            _context = context;
//        }

//        // Lấy tất cả appeal
//        public async Task<List<Appeal>> GetAll()
//        {
//            return await _context.Appeals
//                .Include(a => a.Event)
//                .Include(a => a.Student)
//                    .ThenInclude(s => s.StudentClass)
//                        .ThenInclude(sc => sc.Major)
//                            .ThenInclude(m => m.Faculty)
//                .Include(a => a.Manager)
//                .ToListAsync();
//        }

//        // Lấy theo Id
//        public async Task<Appeal?> GetById(int id)
//        {
//            return await _context.Appeals
//                .Include(a => a.Event)
//                .Include(a => a.Student)
//                    .ThenInclude(s => s.StudentClass)
//                        .ThenInclude(sc => sc.Major)
//                            .ThenInclude(m => m.Faculty)
//                .Include(a => a.Manager)
//                .FirstOrDefaultAsync(a => a.Id == id);
//        }

//        // Tạo appeal mới
//        public async Task<ValidateAppealResult> Create(CreateAppealDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Content))
//                return ValidateAppealResult.EmptyContent;

//            if (string.IsNullOrWhiteSpace(dto.ImagePath))
//                return ValidateAppealResult.EmptyImagePath;

//            if (!await _context.Events.AnyAsync(ev => ev.Id == dto.EventId))
//                return ValidateAppealResult.InvalidEvent;

//            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
//                return ValidateAppealResult.InvalidStudent;

//            Appeal appeal = new Appeal
//            {
//                Content = dto.Content,
//                ImagePath = dto.ImagePath,
//                EventId = dto.EventId,
//                StudentUserId = dto.StudentUserId,
//                Status = AppealStatus.Pending,
//                Response = null,
//                ManagerUserId = null
//            };

//            await _context.Appeals.AddAsync(appeal);
//            await _context.SaveChangesAsync();
//            return ValidateAppealResult.Success;
//        }

//        // Cập nhật appeal (manager trả lời hoặc chỉnh sửa)
//        public async Task<ValidateAppealResult> Update(Appeal appeal, UpdateAppealDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Content))
//                return ValidateAppealResult.EmptyContent;

//            if (string.IsNullOrWhiteSpace(dto.ImagePath))
//                return ValidateAppealResult.EmptyImagePath;

//            if (!await _context.Events.AnyAsync(ev => ev.Id == dto.EventId))
//                return ValidateAppealResult.InvalidEvent;

//            if (!await _context.Students.AnyAsync(s => s.UserId == dto.StudentUserId))
//                return ValidateAppealResult.InvalidStudent;

//            appeal.Content = dto.Content;
//            appeal.ImagePath = dto.ImagePath;
//            appeal.EventId = dto.EventId;
//            appeal.StudentUserId = dto.StudentUserId;
//            appeal.Status = dto.Status;
//            appeal.Response = dto.Response;
//            appeal.ManagerUserId = dto.ManagerUserId;

//            await _context.SaveChangesAsync();
//            return ValidateAppealResult.Success;
//        }

//        // Xóa appeal
//        public async Task Delete(Appeal appeal)
//        {
//            _context.Appeals.Remove(appeal);
//            await _context.SaveChangesAsync();
//        }
//    }

//    public enum ValidateAppealResult
//    {
//        Success,
//        EmptyContent,
//        EmptyImagePath,
//        InvalidEvent,
//        InvalidStudent
//    }
//}