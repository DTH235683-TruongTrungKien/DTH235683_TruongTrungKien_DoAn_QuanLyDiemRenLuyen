using QLDRL.Models;

namespace QLDRL.DTOs.UserDTOs
{
    public class CreateUpdateUserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public List<int> RoleIds { get; set; } = new List<int>();
    }
}
