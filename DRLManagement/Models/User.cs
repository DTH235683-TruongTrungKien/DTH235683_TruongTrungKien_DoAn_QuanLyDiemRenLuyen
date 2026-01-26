namespace QLDRL.Models
{

    public class User
    {
        public int Id {  get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Student;
        public DateTime? BirthDay { get; set; }
        public string? StudentCode { get; set; }
        public double? GPA {  get; set; }
        public ICollection<Event>? Events { get; set; }
        public ICollection<EventDetail>? EventDetail { get; set; }
    }
}
