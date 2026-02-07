using System.ComponentModel.DataAnnotations;

namespace QLDRL.Models
{
    public class Student
    {
        [Key]
        public int UserId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string EnrollmentYear { get; set; } = string.Empty;
        public string GraduationYear {  get; set; } = string.Empty;
        public double GPA { get; set; } = 0;
        public int StudentClassId { get; set; }
        public User User { get; set; } = null!;
        public StudentClass StudentClass { get; set; } = null!;
        public ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();
        public ICollection<PointDetail> PointDetails { get; set; } = new List<PointDetail>();
    }
}