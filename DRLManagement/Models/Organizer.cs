namespace QLDRL.Models
{
    public class Organizer
    {
        public int UserId { get; set; }
        public string OrganizerCode { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int TotalEvents { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
