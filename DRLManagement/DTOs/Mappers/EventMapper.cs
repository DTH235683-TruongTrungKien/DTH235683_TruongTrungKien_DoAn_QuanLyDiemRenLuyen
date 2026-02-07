using QLDRL.DTOs.EventDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class EventMapper
    {
        public static EventDTO ToEventDTO(Event ev)
        {
            return new EventDTO
            {
                Id = ev.Id,
                Name = ev.Name,
                Description = ev.Description,
                ImagePath = ev.ImagePath,
                Status = ev.Status,
                CreatedAt = ev.CreatedAt,
                RegistrationExpired = ev.RegistrationExpired,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,
                OrganizationUnit = ev.OrganizationUnit,
                Location = ev.Location,
                SemesterName = ev.Semester.Name,
                PointCategory = ev.PointCategory.Category,
                AddPoint = ev.AddPoint,
                RemovePoint = ev.RemovePoint,
                OrganizerName = ev.Organizer!.User.FullName,
                RegisteredAmount = ev.EventRegistrations.Count(),
                TargetedAmount = ev.TargetedAmount,
                AllowFaculties = ev.AllowFaculties.Count > 0
                    ? string.Join(", ", ev.AllowFaculties.Select(x => x.Name))
                    : "(Sinh viên toàn trường)",
                AllowClasses = ev.AllowClasses.Count > 0
                    ? string.Join(", ", ev.AllowClasses.Select(c => c.Name))
                    : "(Sinh viên toàn trường)"
            };
        }

        public static List<EventDTO> ToEventDTOList(List<Event> events)
        {
            return events.Select(ev => ToEventDTO(ev)).ToList();
        }

        public static Event ToEvent(CreateUpdateEventDTO dto)
        {
            return new Event
            {
                Name = dto.Name,
                Description = dto.Description,
                ImagePath = dto.ImagePath,
                Status = dto.Status ?? EventStatus.Pending,
                CreatedAt = DateTime.Now,
                RegistrationExpired = dto.RegistrationExpired,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                OrganizationUnit = dto.OrganizationUnit,
                Location = dto.Location,
                SemesterId = dto.SemesterId,
                PointCategoryId = dto.PointCategoryId,
                OrganizerUserId = dto.OrganizerUserId,
                TargetedAmount = dto.TargetedAmount,
                AddPoint = dto.AddPoint,
                RemovePoint = dto.RemovePoint
            };
        }
        public static CreateUpdateEventDTO ToCreateUpdateEventDTO(Event ev)
        {
            return new CreateUpdateEventDTO
            {
                Id = ev.Id,

                Name = ev.Name,
                Description = ev.Description,
                ImagePath = ev.ImagePath,

                RegistrationExpired = ev.RegistrationExpired,
                StartDate = ev.StartDate,
                EndDate = ev.EndDate,

                OrganizationUnit = ev.OrganizationUnit,
                Location = ev.Location,
                PointCategoryId = ev.PointCategoryId,
                SemesterId = ev.SemesterId,
                
                OrganizerUserId = ev.OrganizerUserId,

                TargetedAmount = ev.TargetedAmount,

                AllowFacultyIds = ev.AllowFaculties?
                    .Select(f => f.Id)
                    .ToList() ?? new List<int>(),

                AllowClassIds = ev.AllowClasses?
                    .Select(c => c.Id)
                    .ToList() ?? new List<int>(),

                AddPoint = ev.AddPoint,
                RemovePoint = ev.RemovePoint,
            };
        }

        public static void MapUpdate(Event ev, CreateUpdateEventDTO dto)
        {
            ev.Name = dto.Name;
            ev.Description = dto.Description;
            ev.ImagePath = dto.ImagePath;
            ev.RegistrationExpired = dto.RegistrationExpired;
            ev.StartDate = dto.StartDate;
            ev.EndDate = dto.EndDate;
            ev.OrganizationUnit = dto.OrganizationUnit;
            ev.Location = dto.Location;
            ev.SemesterId = dto.SemesterId;
            ev.OrganizerUserId = dto.OrganizerUserId;
            ev.PointCategoryId = dto.PointCategoryId;
            ev.AddPoint = dto.AddPoint;
            ev.RemovePoint = dto.RemovePoint;
            ev.TargetedAmount = dto.TargetedAmount;
        }

        public static List<EventRegistrationDTO> ToEventRegistrationDTOList(List<EventRegistration> erList)
        {
            return erList.Select(er => new EventRegistrationDTO
            {
                EventId = er.EventId,
                EventName = er.Event.Name,
                SemesterName = er.Event.Semester.Name,
                RegisteredDate = er.RegisteredAt.ToString(),
                StartDate = er.Event.StartDate.ToString(),
                EndDate = er.Event.EndDate.ToString(),
                Score = er.Event.AddPoint,
                AttendStatus = er.AttendStatus,
            }).ToList();
        }
    }
}