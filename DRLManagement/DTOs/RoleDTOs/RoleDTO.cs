using QLDRL.Models;

namespace QLDRL.DTOs.RoleDTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new();
    }
}
