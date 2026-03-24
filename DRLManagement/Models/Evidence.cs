namespace QLDRL.Models
{
    public class Evidence
    {
        public int Id { get; set; } 
        public string Title {  get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int StudentUserId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
