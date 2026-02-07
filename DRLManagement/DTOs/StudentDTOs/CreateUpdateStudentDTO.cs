namespace QLDRL.DTOs.StudentDTOs
{
    public class CreateUpdateStudentDTO
    {
        public int UserId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public int StudentClassId { get; set; }
        public string EnrollmentYear { get; set; } = string.Empty;
        public string GraduationYear {  get; set; } = string.Empty;
        public double GPA { get; set; } = 0;
    }
}
