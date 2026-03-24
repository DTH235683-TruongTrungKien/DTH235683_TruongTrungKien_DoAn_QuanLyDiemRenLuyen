using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Helpers.States;
using QLDRL.Models;
using QLDRL.Services;
using System.Threading.Tasks;

namespace QLDRL.Presentation.Admin.Dialogs
{
    
    public partial class frmAddUserPopup : Form
    {
        private readonly UserServices _userServices;
        private readonly RoleServices _roleServices;
        private readonly StudentService _studentServcie;
        private AddUserRoleState _state = new();
        private List<Role> _roles;
        private int _adminRoleId;
        private int _managerRoleId;
        private int _organizerRoleId;
        private int _studentRoleId;


        public frmAddUserPopup(UserServices userServices, RoleServices roleServices, StudentService studentService)
        {
            InitializeComponent();
            _userServices = userServices;
            _roleServices = roleServices;
            _studentServcie = studentService;
        }

        private async Task loadAllRoles()
        {
            _roles = await _roleServices.GetAll();
            _adminRoleId = (await _roleServices.GetByName("Admin")).Id;
            _managerRoleId = (await _roleServices.GetByName("Manager")).Id;
            _organizerRoleId = (await _roleServices.GetByName("Organizer")).Id;
            _studentRoleId = (await _roleServices.GetByName("Student")).Id;
        }
        private void cboRoles_Load()
        {
            cboRoles.DisplayMember = "Name";
            cboRoles.ValueMember = "Id";
            cboRoles.DataSource = _roles;
            cboRoles.SelectedValue = _studentRoleId;
        }

        private async void frmAddUserPopup_Load(object sender, EventArgs e)
        {
            await loadAllRoles();
            cboRoles_Load();
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var userDTO = new CreateUserDTO
            {
                Email = txtEmail.Text,
                Password = Utils.HashPassword(txtPassword.Text),
                FullName = txtName.Text,
                Birthday = !string.IsNullOrWhiteSpace(txtBirthday.Text) ? DateOnly.Parse(txtBirthday.Text) : DateOnly.MinValue,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RoleIds = _state.RoleIds
            };
            var validationResult = await _userServices.Create(userDTO);
            switch (validationResult)
            {
                case ValidateUserResult.EmptyEmail:
                    Utils.ShowMessages("Lỗi xác thực", "Email không được để trống", this);
                    txtEmail.Focus();
                    return;

                case ValidateUserResult.InvalidEmail:
                    Utils.ShowMessages("Lỗi xác thực", "Email không đúng định dạng", this);
                    txtEmail.Focus();
                    return;

                case ValidateUserResult.EmptyName:
                    Utils.ShowMessages("Lỗi xác thực", "Tên không được để trống", this);
                    txtName.Focus();
                    return;

                case ValidateUserResult.InvalidBirthday:
                    Utils.ShowMessages("Lỗi xác thực", "Ngày sinh không hợp lệ", this);
                    txtBirthday.Focus();
                    return;

                case ValidateUserResult.InvalidPhoneNumber:
                    Utils.ShowMessages("Lỗi xác thực", "Số điện thoại không hợp lệ", this);
                    txtPhoneNumber.Focus();
                    return;

                case ValidateUserResult.EmptyPassword:
                    Utils.ShowMessages("Lỗi xác thực", "Mật khẩu không được để trống", this);
                    txtPassword.Focus();
                    return;

                case ValidateUserResult.ShortPassword:
                    Utils.ShowMessages("Lỗi xác thực", "Mật khẩu phải ít nhất 5 ký tự", this);
                    txtPassword.Focus();
                    return;

                case ValidateUserResult.NoRoleSelected:
                    Utils.ShowMessages("Lỗi xác thực", "Người dùng phải có ít nhất một vai trò", this);
                    cboRoles.Focus();
                    return;

                case ValidateUserResult.Success:
                    var user = await _userServices.GetByUserEmail(userDTO.Email);
                    var createStudentResult = await _studentServcie.Create(_state.Student, user);
                    switch (createStudentResult)
                    {
                        case ValidateStudentResult.InvalidStudentCode:
                            Utils.ShowMessages("Lỗi", "Mã sinh viên không hợp lệ", this);
                            await _userServices.Delete(user);
                            return;

                        case ValidateStudentResult.StudentClassNotFound:
                            Utils.ShowMessages("Lỗi", "Lớp không tồn tại", this);
                            await _userServices.Delete(user);
                            return;

                        case ValidateStudentResult.InvalidEnrollmentYear:
                            Utils.ShowMessages("Lỗi", "Năm nhập học không hợp lệ", this);
                            await _userServices.Delete(user);
                            return;

                        case ValidateStudentResult.InvalidGraduationYear:
                            Utils.ShowMessages("Lỗi", "Năm tốt nghiệp không hợp lệ", this);
                            await _userServices.Delete(user);
                            return;

                        case ValidateStudentResult.InvalidGPA:
                            Utils.ShowMessages("Lỗi", "Điểm học tập không hợp lệ (0.0 - 10.0)", this);
                            await _userServices.Delete(user);
                            return;

                        case ValidateStudentResult.Success:
                            Utils.ShowMessages("Success", "Tạo người dùng thành công!", this);
                            break;
                    }
                    break;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roleId = Convert.ToInt32(cboRoles.SelectedValue);
            if (roleId == _adminRoleId)
            {
                pnlProfile.Controls.Clear();
            }
            if (roleId == _managerRoleId)
            {
                pnlProfile.Controls.Clear();
            }
            if (roleId == _organizerRoleId)
            {
                pnlProfile.Controls.Clear();
            }
            if (roleId == _studentRoleId)
            {
                var studentForm = new ucStudentForm(_state, _studentRoleId);
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(studentForm);
            }
        }
    }
}
