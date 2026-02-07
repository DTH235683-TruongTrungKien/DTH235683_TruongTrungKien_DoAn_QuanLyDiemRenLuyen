using QLDRL.Enums;
using QLDRL.Models;

namespace QLDRL.DTOs.EventDTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public EventStatus Status { get; set; } = EventStatus.Pending;
        public DateTime CreatedAt { get; set; }
        public DateTime RegistrationExpired { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrganizationUnit { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public string OrganizerName { get; set; } = string.Empty;
        public string PointCategory {  get; set; } = string.Empty;
        public double AddPoint { get; set; } 
        public double RemovePoint { get; set; } 
        public int RegisteredAmount {  get; set; } 
        public int TargetedAmount { get; set; } 
        public string AllowFaculties { get; set; } = string.Empty;
        public string AllowClasses { get; set; } = string.Empty;
    }
}
