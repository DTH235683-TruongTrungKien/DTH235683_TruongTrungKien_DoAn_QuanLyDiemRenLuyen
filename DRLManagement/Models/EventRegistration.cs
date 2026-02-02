namespace QLDRL.Models
{
    public class EventRegistration
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public DateTime RegisteredAt { get; set; }
        public bool IsAttended { get; set; }
    }
}
