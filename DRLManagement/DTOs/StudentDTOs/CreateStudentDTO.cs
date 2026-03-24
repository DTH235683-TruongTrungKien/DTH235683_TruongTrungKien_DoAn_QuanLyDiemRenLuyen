namespace QLDRL.DTOs.StudentDTOs
{
    public class CreateStudentDTO
    {
        public int UserId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentClassName { get; set; } = string.Empty;
        public string EnrollmentYear { get; set; } = string.Empty;
        public string GraduationYear {  get; set; } = string.Empty;
        public double GPA { get; set; } = 0;
    }
}
