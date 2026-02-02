using System;
using System.Collections.Generic;
using System.Linq;
namespace QLDRL.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string EventDescription { get; set; } = string.Empty;
        public double AddPoint { get; set; }
        public double RemovePoint { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
        public int? OrganizerId { get; set; }
        public Organizer? Organizer { get; set; }
        public int? ManagerId { get; set; }
        public Manager? Manager { get; set; } 
        public ICollection<EventRegistration> Details { get; set; } = new List<EventRegistration>();
    }
}
