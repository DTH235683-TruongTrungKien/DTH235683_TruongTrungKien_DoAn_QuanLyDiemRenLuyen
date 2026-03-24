namespace QLDRL.Models
{
    public enum AppealStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class Appeal
    {
        public int Id { get; set; }
        public string Content {  get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public AppealStatus Status { get; set; } = AppealStatus.Pending;
        public string? Response { get; set; } 
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int StudentUserId { get; set; }
        public Student Student { get; set; } = null!;
        public int? ManagerUserId { get; set; }
        public Manager? Manager { get; set; } = null!;

    }
}
