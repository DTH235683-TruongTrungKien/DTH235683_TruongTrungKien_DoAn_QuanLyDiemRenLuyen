namespace QLDRL.DTOs.StudentDTOs
{
    public class UpdateStudentDTO
    {
        public string? StudentCode { get; set; } = string.Empty;
        public string? StudentClassName { get; set; }
        public string? EnrollmentYear { get; set; } = string.Empty;
        public string? GraduationYear { get; set; } = string.Empty;
        public double? GPA { get; set; } = 0;
    }
}
