namespace QLDRL.Models
{
    public class Student
    {
        public int UserId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string ClassName {  get; set; } = string.Empty;
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; } = string.Empty;
        public double? GPA { get; set; }
        public User User { get; set; } = null!;
        public ICollection<EventRegistration>? EventDetails { get; set; }
    }
}