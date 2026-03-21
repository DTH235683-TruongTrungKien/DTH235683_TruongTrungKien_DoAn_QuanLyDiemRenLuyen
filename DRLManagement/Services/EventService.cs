using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.EventDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;

namespace QLDRL.Services
{
    public class EventService
    {
        private readonly AppDbContext _context;
        private readonly PointCategoryService _pointCategoryService;

        public EventService(AppDbContext context, PointCategoryService pointCategoryService)
        {
            _context = context;
            _pointCategoryService = pointCategoryService;
        }


        public async Task<List<Event>> GetAll()
        {
            return await _context.Events
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o.User)
                .Include(e => e.PointCategory)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .ToListAsync();
        }
        public async Task<List<Event>> SearchEvents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAll();

            keyword = keyword.ToLower();
            return await _context.Events
                .Where(e => e.Name.ToLower().Contains(keyword))
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o!.User)
                .Include(e => e.PointCategory)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .ToListAsync();
        }
        public async Task<List<Event>> GetAllByName(string eventName)
        {
            return await _context.Events
                .Where(e  => e.Name == eventName)
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o!.User)
                .Include(e => e.PointCategory)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .ToListAsync();
        }
        public async Task<List<Event>> GetAllByOrganizerId(int organizerId)
        {
            return await _context.Events
                .Where(e => e.OrganizerUserId == organizerId)
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o!.User)
                .Include(e => e.PointCategory)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .ToListAsync();
        }
        public async Task<List<Event>> GetAllForStudent(int studentClassId, int facultyId)
        {
            return await _context.Events
                .Where(e => !e.AllowClasses.Any() || e.AllowClasses.Any(c => c.Id == studentClassId))
                .Where(e => !e.AllowFaculties.Any() || e.AllowFaculties.Any(f => f.Id == facultyId))
                .Where(e => e.Status != EventStatus.Pending && e.Status != EventStatus.Rejected)
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o!.User)
                .Include(e => e.PointCategory)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .ToListAsync();
        }

        public async Task<List<Event>> GetAllByStatus(params EventStatus[] status)
        {
            return await _context.Events
                .Where(e => status.Contains(e.Status))
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o!.User)
                .Include(e => e.PointCategory)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .ToListAsync();
        }
        public async Task<Event?> GetById(int id)
        {
            return await _context.Events
                .Include(e => e.Semester)
                .Include(e => e.Organizer)
                    .ThenInclude(o => o!.User)
                .Include(e => e.EventRegistrations)
                .Include(e => e.EventRegistrations)
                .Include(e => e.AllowFaculties)
                .Include(e => e.AllowClasses)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ValidateEventResult> Validate(CreateUpdateEventDTO dto)
        {
            if (dto == null)
                return ValidateEventResult.NotFound;

            if (string.IsNullOrWhiteSpace(dto.Name))
                return ValidateEventResult.EmptyName;

            if (string.IsNullOrWhiteSpace(dto.OrganizationUnit))
                return ValidateEventResult.EmptyOrganizationUnit;

            if (!await _context.Semesters.AnyAsync(s => s.Id == dto.SemesterId))
                return ValidateEventResult.InvalidSemester;

            var now = DateTime.Now;

            if (dto.RegistrationExpired <= now)
                return ValidateEventResult.InvalidRegistrationExpired;

            if (dto.StartDate <= dto.RegistrationExpired)
                return ValidateEventResult.InvalidStartDate;

            if (dto.EndDate <= dto.StartDate)
                return ValidateEventResult.InvalidEndDate;

            var pointCategory = await _pointCategoryService.GetById(dto.PointCategoryId);
            if (dto.AddPoint <= 0 || dto.AddPoint > pointCategory.MaxScore || dto.RemovePoint < 0)
                return ValidateEventResult.InvalidPoint;

            if (dto.TargetedAmount < 0)
                return ValidateEventResult.InvalidAmount;

            return ValidateEventResult.Success;
        }

        public async Task<int> Create(CreateUpdateEventDTO dto)
        {
            var ev = EventMapper.ToEvent(dto);
            await _context.Events.AddAsync(ev);
                await _context.SaveChangesAsync();
            return ev.Id;
        }

        public async Task<int> Update(int id, CreateUpdateEventDTO dto)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

            EventMapper.MapUpdate(ev, dto);

            await _context.SaveChangesAsync();
            return ev.Id;
        }

        public async Task<ValidateEventResult> Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null)
                return ValidateEventResult.NotFound;

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return ValidateEventResult.Success;
        }
        public async Task<ValidateEventResult> VerifyEvent(int eventId, bool isVerify)
        {
            var ev = await GetById(eventId);
            if (ev == null)
                return ValidateEventResult.NotFound;
            else if (ev.Status != EventStatus.Pending)
                return ValidateEventResult.VerifyFailed;
            ev.Status = isVerify ? EventStatus.Upcoming : EventStatus.Rejected;
            await _context.SaveChangesAsync();
            return ValidateEventResult.Success;

        }

        // Event Registration
        public async Task<List<EventRegistration>> GetAllStudentRegisteredEvents(int studentUserId)
        {
            return await _context.EventRegistrations
                .Where(er => er.StudentUserId == studentUserId)
                .Include(er => er.Event)
                    .ThenInclude(ev => ev.Semester)
                .ToListAsync();
        }
        public async Task<EventRegistration?> GetRegisteredEventById(int studentUserId, int eventId)
        {
            return await _context.EventRegistrations
                .Include(er => er.Event)
                .FirstOrDefaultAsync(er => er.StudentUserId == studentUserId && er.EventId == eventId);
        }
        public async Task<RegisterEventResult> RegisterEvent(int eventId, int studentUserId)
        {
            if(_context.EventRegistrations.Any(er => er.EventId == eventId && er.StudentUserId == studentUserId))
                return RegisterEventResult.IsRegistered;
            var eventRegistration = new EventRegistration
            {
                EventId = eventId,
                StudentUserId = studentUserId,
                AttendStatus = AttendStatus.Processing,
                RegisteredAt = DateTime.Now,
            };
            await _context.EventRegistrations.AddAsync(eventRegistration);
            await _context.SaveChangesAsync();
            return RegisterEventResult.Success;
        }
        public async Task<RegisterEventResult> UnregisterEvent(int eventId, int studentUserId)
        {
            var er = await _context.EventRegistrations.FirstOrDefaultAsync(er => er.EventId == eventId && er.StudentUserId == studentUserId);
            if(er.RegisteredAt.AddMinutes(30) <= DateTime.Now)
            {
                return RegisterEventResult.OutOfTime;
            }
            _context.EventRegistrations.Remove(er);
            await _context.SaveChangesAsync();
            return RegisterEventResult.Success;
        }
        public async Task UpdateEventStatus()
        {
            var now = DateTime.Now;

            var events = await GetAllByStatus(EventStatus.Upcoming, EventStatus.Ongoing);

            foreach (var e in events)
            {
                if (e.StartDate <= now && e.Status == EventStatus.Upcoming)
                {
                    e.Status = EventStatus.Ongoing;
                }
                else if (e.EndDate <= now && e.Status == EventStatus.Ongoing)
                {
                    e.Status = EventStatus.Completed;
                }
            }
                
            await _context.SaveChangesAsync();
        }

        public async Task SetRegisterStatus(EventRegistration er, AttendStatus status)
        {
            er.AttendStatus = status;
            await _context.SaveChangesAsync();
        }

    }


}