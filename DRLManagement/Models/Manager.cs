namespace QLDRL.Models
{
    public class Manager
    {
        public int UserId { get; set; }
        public string Position { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        public DateTime AssignedDate {  get; set; }
        public User User { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<Evidence> Evidences { get; set; } = new List<Evidence>();
        public ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();
        public ICollection<Confirm> Confirms { get; set; } = new List<Confirm>();
    }
}
