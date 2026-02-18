using QLDRL.DTOs.AdminDTOs;
using QLDRL.DTOs.ManagerDTOs;
using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.DTOs.StudentDTOs;

namespace QLDRL.Helpers.States
{
    public class AddUserRoleState
    {
        public List<int> RoleIds { get; set; } = new();
        public CreateUpdateAdminDTO? AdminDTO { get; set; }
        public CreateUpdateManagerDTO? ManagerDTO { get; set; }
        public CreateUpdateOrganizerDTO? OrganizerDTO { get; set; }
        public CreateUpdateStudentDTO? StudentDTO { get; set; }
    }
}