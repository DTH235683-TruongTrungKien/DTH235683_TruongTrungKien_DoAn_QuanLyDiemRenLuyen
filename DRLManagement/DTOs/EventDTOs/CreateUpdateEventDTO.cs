using QLDRL.Enums;
using QLDRL.Models;

namespace QLDRL.DTOs.EventDTOs
{
    public class CreateUpdateEventDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public EventStatus? Status {  get; set; }
        public DateTime RegistrationExpired { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrganizationUnit { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int SemesterId { get; set; }
        public int? OrganizerUserId { get; set; }
        public int TargetedAmount { get; set; } = 0;
        public int PointCategoryId { get; set; }
        public double AddPoint { get; set; } = 0;
        public double RemovePoint { get; set; } = 0;
        public List<int> AllowFacultyIds { get; set; } = new();
        public List<int> AllowClassIds { get; set; } = new();
    }
}
