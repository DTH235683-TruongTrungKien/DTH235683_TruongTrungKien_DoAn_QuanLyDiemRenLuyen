//using Microsoft.EntityFrameworkCore;
//using QLDRL.Data;
//using QLDRL.DTOs.EventDTOs;
//using QLDRL.Models;
//using QLDRL.DTOs.Mappers;
//using QLDRL.Helpers;

//namespace QLDRL.Services
//{
//    public class EventServices
//    {
//        private readonly AppDbContext _context;

//        public EventServices(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Event>> GetAll()
//        {
//            return await _context.Events
//                .Include(e => e.Semester)
//                .Include(e => e.Organizer)
//                .Include(e => e.Manager)
//                .Include(e => e.EventDetails)
//                    .ThenInclude(ed => ed.PointCategory)
//                .Include(e => e.EventRegistrations)
//                .Include(e => e.AllowFaculties)
//                .Include(e => e.AllowClasses)
//                .ToListAsync();
//        }

//        public async Task<Event?> GetById(int id)
//        {
//            return await _context.Events
//                .Include(e => e.Semester)
//                .Include(e => e.Organizer)
//                .Include(e => e.Manager)
//                .Include(e => e.EventDetails)
//                    .ThenInclude(ed => ed.PointCategory)
//                .Include(e => e.EventRegistrations)
//                .Include(e => e.AllowFaculties)
//                .Include(e => e.AllowClasses)
//                .FirstOrDefaultAsync(e => e.Id == id);
//        }

//        public async Task<ValidateEventResult> Create(CreateEventDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.EventName))
//                return ValidateEventResult.EmptyName;

//            if (string.IsNullOrWhiteSpace(dto.EventDescription))
//                return ValidateEventResult.EmptyDescription;

//            if (dto.SemesterId <= 0 || !await _context.Semesters.AnyAsync(s => s.Id == dto.SemesterId))
//                return ValidateEventResult.InvalidSemester;

//            if (dto.StartDate <= DateTime.Now)
//                return ValidateEventResult.InvalidStartDate;

//            if (dto.RegistrationExpired <= DateTime.Now)
//                return ValidateEventResult.InvalidRegistrationExpired;

//            if (dto.EndDate <= DateTime.Now)
//                return ValidateEventResult.InvalidEndDate;

//            if (dto.PointDetails == null || !dto.PointDetails.Any())
//                return ValidateEventResult.NoPointDetail;

//            Event ev = EventMapper.ToEvent(dto);
//            ev.CreatedAt = DateTime.Now;

//            foreach (var pd in dto.PointDetails)
//            {
//                ev.EventDetails.Add(new EventDetail
//                {
//                    Event = ev,
//                    PointCategoryId = pd.PointCategoryId,
//                    AddPoint = pd.AddPoint,
//                    RemovePoint = pd.RemovePoint
//                });
//            }

//            await _context.Events.AddAsync(ev);
//            await _context.SaveChangesAsync();
//            return ValidateEventResult.Success;
//        }

//        public async Task<ValidateEventResult> Update(Event ev, UpdateEventDTO dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.EventName))
//                return ValidateEventResult.EmptyName;

//            if (string.IsNullOrWhiteSpace(dto.EventDescription))
//                return ValidateEventResult.EmptyDescription;

//            if (dto.SemesterId <= 0 || !await _context.Semesters.AnyAsync(s => s.Id == dto.SemesterId))
//                return ValidateEventResult.InvalidSemester;

//            if (dto.StartDate <= ev.CreatedAt)
//                return ValidateEventResult.InvalidStartDate;

//            if (dto.RegistrationExpired <= ev.CreatedAt)
//                return ValidateEventResult.InvalidRegistrationExpired;

//            if (dto.EndDate <= ev.CreatedAt)
//                return ValidateEventResult.InvalidEndDate;

//            if (dto.PointDetails == null || !dto.PointDetails.Any())
//                return ValidateEventResult.NoPointDetail;

//            EventMapper.MapUpdate(ev, dto);

//            ev.EventDetails.Clear();
//            foreach (var pd in dto.PointDetails)
//            {
//                ev.EventDetails.Add(new EventDetail
//                {
//                    Event = ev,
//                    PointCategoryId = pd.PointCategoryId,
//                    AddPoint = pd.AddPoint,
//                    RemovePoint = pd.RemovePoint
//                });
//            }

//            await _context.SaveChangesAsync();
//            return ValidateEventResult.Success;
//        }

//        public async Task Delete(Event ev)
//        {
//            _context.Events.Remove(ev);
//            await _context.SaveChangesAsync();
//        }
//    }

//    public enum ValidateEventResult
//    {
//        Success,
//        EmptyName,
//        EmptyDescription,
//        InvalidSemester,
//        InvalidStartDate,
//        InvalidRegistrationExpired,
//        InvalidEndDate,
//        NoPointDetail
//    }
//}