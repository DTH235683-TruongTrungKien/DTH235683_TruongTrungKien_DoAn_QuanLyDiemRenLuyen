using QLDRL.DTOs.AdminDTOs;
using QLDRL.DTOs.ManagerDTOs;
using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.DTOs.StudentDTOs;

namespace QLDRL.DTOs.UserDTOs
{
    public class CurrentUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<string> RoleNames { get; set; } = new();
        public AdminDTO? Admin {  get; set; }
        public ManagerDTO? Manager { get; set; }
        public OrganizerDTO? Organizer { get; set; }
        public StudentDTO? Student { get; set; }
    }
}
