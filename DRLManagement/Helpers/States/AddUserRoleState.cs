using QLDRL.DTOs.StudentDTOs;

namespace QLDRL.Helpers.States
{
    public class AddUserRoleState
    {
        public List<int> RoleIds { get; set; } = new();
        //public CreateAdminDTO? Admin {  get; set; }
        public CreateStudentDTO? Student { get; set; }
    }
}
