namespace QLDRL.DTOs.StudentDTOs
{
    public class CreateUpdateStudentDTO
    {
        public int UserId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; } = string.Empty;
        public double? GPA { get; set; }
    }
}
