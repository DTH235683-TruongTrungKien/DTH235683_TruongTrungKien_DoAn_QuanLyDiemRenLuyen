namespace QLDRL.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime RegistrationExpired {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
        public int? OrganizerUserId { get; set; }
        public Organizer? Organizer { get; set; }
        public int? ManagerUserId { get; set; }
        public Manager? Manager { get; set; } 
        public ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
        public ICollection<EventDetail> EventDetails { get; set; } = new List<EventDetail>();
        public ICollection<Faculty> AllowFaculties { get; set; } = new List<Faculty>();
        public ICollection<StudentClass> AllowClasses { get; set; } = new List<StudentClass>();
    }
}
