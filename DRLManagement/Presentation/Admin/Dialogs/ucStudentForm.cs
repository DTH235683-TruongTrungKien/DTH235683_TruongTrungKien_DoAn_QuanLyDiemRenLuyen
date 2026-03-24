using QLDRL.DTOs.StudentDTOs;
using QLDRL.Helpers;
using QLDRL.Helpers.States;

namespace QLDRL.Presentation.Admin.Dialogs
{
    public partial class ucStudentForm : UserControl
    {
        private AddUserRoleState _state;
        private readonly int _studentRoleId;
        public ucStudentForm(AddUserRoleState state, int studentRoleId)
        {
            InitializeComponent();
            _state = state;
            _studentRoleId = studentRoleId;
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            if (_state.RoleIds.Contains(_studentRoleId))
            {
                Utils.ShowMessages("Lỗi thực thi", "Vai trò này đã tồn tại", this.ParentForm!);
                return;
            }
            var studentDTO = new CreateStudentDTO
            {
                StudentCode = txtStudentCode.Text,
                StudentClassName = txtStudentClass.Text,
                EnrollmentYear = txtEnrollmentYear.Text,
                GraduationYear = txtGraduationYear.Text,
                GPA = !string.IsNullOrWhiteSpace(txtGPA.Text) ? Convert.ToDouble(txtGPA.Text) : 0.0
            };
            _state.RoleIds.Add(_studentRoleId);
            _state.Student = studentDTO;
            Utils.ShowMessages("Thành công", "Thêm vai trò thành công", this.ParentForm!);
        }
        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            if (!_state.RoleIds.Contains(_studentRoleId))
            {
                Utils.ShowMessages("Lỗi thực thi", "Vai trò này chưa được thêm", this.ParentForm!);
                return;
            }
            _state.RoleIds.Remove(_studentRoleId);
            _state.Student = null;
            Utils.ShowMessages("Thành công", "Gỡ bỏ vai trò thành công", this.ParentForm!);
        }
    }
}
