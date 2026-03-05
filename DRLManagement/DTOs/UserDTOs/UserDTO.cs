using QLDRL.DTOs.RoleDTOs;

namespace QLDRL.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<string> RoleNames { get; set; } = new();
    }
}
