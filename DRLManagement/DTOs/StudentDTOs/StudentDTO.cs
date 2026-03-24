using QLDRL.DTOs.UserDTOs;

namespace QLDRL.DTOs.StudentDTOs
{
    public class StudentDTO
    {
        public int UserId { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string MajorName { get; set; } = string.Empty;
        public string FacultyName {  get; set; } = string.Empty;
        public string SchoolYear {  get; set; } = string.Empty;
        public double GPA { get; set; } = 0;
    }
}
