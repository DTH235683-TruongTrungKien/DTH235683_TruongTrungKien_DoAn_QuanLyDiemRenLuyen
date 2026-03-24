namespace QLDRL.Models
{
    public class EventRegistration
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int StudentUserId { get; set; }
        public Student Student { get; set; } = null!;
        public int PointCategoryId { get; set; }
        public PointCategory PointCategory { get; set; } = null!;
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
        public bool IsAttended { get; set; }
    }
}
