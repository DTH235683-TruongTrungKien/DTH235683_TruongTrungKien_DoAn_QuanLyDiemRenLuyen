using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Services;
using System.Threading.Tasks;

namespace QLDRL.Presentation.Main
{
    public partial class ucAccount : UserControl
    {
        private readonly Session _session;
        private readonly UserServices _userService;
        private readonly AuthServices _authService;
        public ucAccount(Session session, UserServices userService, AuthServices authService)
        {
            InitializeComponent();
            _session = session;
            _userService = userService;
            _authService = authService;
        }

        private async Task loadUserInfo()
        {
            txtEmail.Text = _session.CurrentUser!.Email;
            txtName.Text = _session.CurrentUser.FullName;
            txtBirthday.Text = _session.CurrentUser.Birthday.ToString();
            txtPhoneNumber.Text = _session.CurrentUser.PhoneNumber;
            txtAddress.Text = _session.CurrentUser.Address;
            cboRoles.ValueMember = "Id";
            cboRoles.DisplayMember = "Name";
            var user = await _userService.GetById(_session.CurrentUser.Id);
            cboRoles.DataSource = user!.Roles;
            cboRoles.SelectedIndex = 0;
        }
        private void showAdminInfo(bool state)
        {
            pnlAdminInfo.Visible = state;
            if (state)
            {
                loadAdminInfo();
            }
        }
        private void showManagerInfo(bool state)
        {
            pnlManagerInfo.Visible = state;
            if (state)
            {
                loadManagerInfo();
            }
        }
        private void showOrganizerInfo(bool state)
        {
            pnlOrganizerInfo.Visible = state;
            if (state)
            {
                loadOrganizerInfo();
            }
        }
        private void showStudentInfo(bool state)
        {
            pnlStudentInfo.Visible = state;
            if (state)
            {
                loadStudentInfo();
            }
        }
        private void loadAdminInfo()
        {
            txtPermission.Text = _session.CurrentUser!.Admin!.Permission;
            txtAdminDepartment.Text = _session.CurrentUser.Admin.Department;
        }
        private void loadManagerInfo()
        {
            txtManagerCode.Text = _session.CurrentUser!.Manager!.ManagerCode;
            txtManagerPosition.Text = _session.CurrentUser.Manager.Position;
            txtDepartment.Text = _session.CurrentUser.Manager.Department;
            txtManagerFaculty.Text = _session.CurrentUser.Manager.FacultyName;
        }
        private void loadOrganizerInfo()
        {
            txtClubName.Text = _session.CurrentUser!.Organizer!.ClubName;
            txtPosition.Text = _session.CurrentUser.Organizer.Position;
        }
        private void loadStudentInfo()
        {
            txtStudentCode.Text = _session.CurrentUser!.Student!.StudentCode;
            txtStudentClass.Text = _session.CurrentUser.Student.ClassName;
            txtMajor.Text = _session.CurrentUser.Student.MajorName;
            txtFaculty.Text = _session.CurrentUser.Student.FacultyName;
            txtSchoolYear.Text = _session.CurrentUser.Student.SchoolYear;
            txtGPA.Text = _session.CurrentUser.Student.GPA.ToString();
        }
        private void resetPanel()
        {
            showAdminInfo(false);
            showManagerInfo(false);
            showOrganizerInfo(false);
            showStudentInfo(false);
        }
        private async void ucAccount_Load(object sender, EventArgs e)
        {
            resetPanel();
            await loadUserInfo();
        }
        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetPanel();
            var roleId = (RoleType)Convert.ToInt32(cboRoles.SelectedValue);
            if (roleId == RoleType.Admin)
            {
                showAdminInfo(true);
            }
            else if (roleId == RoleType.Manager)
            {
                showManagerInfo(true);
            }
            else if (roleId == RoleType.Organizer)
            {
                showOrganizerInfo(true);
            }
            else if (roleId == RoleType.Student)
            {
                showStudentInfo(true);
            }
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewPassword.Text) && txtNewPassword.Text.Length < 6)
            {
                Utils.ShowMessages("Validation", "Mật khẩu phải ít nhất 6 ký tự", this.ParentForm!);
                txtNewPassword.Focus();
                return;
            }
            var changePasswordDTO = new ChangePasswordDTO
            {
                Email = txtEmail.Text,
                OldPassword = txtOldPassword.Text,
                NewPassword = txtNewPassword.Text,
                ConfirmPassword = txtConfirmPassword.Text
            };
            var resultMessages = await _authService.ChangePassword(changePasswordDTO);
            switch (resultMessages)
            {
                case ChangePasswordResult.Success:
                    Utils.ShowMessages("Thành công", "Đổi mật khẩu thành công!", this.ParentForm!);
                    break;

                case ChangePasswordResult.OldPasswordIncorrect:
                    Utils.ShowMessages("Lỗi", "Mật khẩu cũ không chính xác!", this.ParentForm!);
                    break;

                case ChangePasswordResult.ConfirmPasswordIncorrect:
                    Utils.ShowMessages("Lỗi", "Mật khẩu nhập lại không chính xác!", this.ParentForm!);
                    break;
            }
        }
    }
}
