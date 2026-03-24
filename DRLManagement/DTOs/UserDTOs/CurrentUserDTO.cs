using QLDRL.DTOs.StudentDTOs;

namespace QLDRL.DTOs.UserDTOs
{
    public class CurrentUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<string> RoleNames { get; set; } = new();
        public StudentDTO? Student {  get; set; }
    }
}
