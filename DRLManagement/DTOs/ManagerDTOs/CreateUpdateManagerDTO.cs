namespace QLDRL.DTOs.ManagerDTOs
{
    public class CreateUpdateManagerDTO
    {
        public int UserId { get; set; }
        public string ManagerCode { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string FacultyName { get; set; } = string.Empty;
    }
}
