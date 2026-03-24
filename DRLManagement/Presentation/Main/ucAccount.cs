using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            showStudentInfo(false);
        }

        private void loadUserInfo()
        {
            txtEmail.Text = _session.CurrentUser.Email;
            txtName.Text = _session.CurrentUser.FullName;
            txtBirthday.Text = _session.CurrentUser.Birthday.ToString();
            txtPhoneNumber.Text = _session.CurrentUser.PhoneNumber;
            txtAddress.Text = _session.CurrentUser.Address;
            txtRole.Text = Utils.ListToString(_session.CurrentUser.RoleNames);
        }
        private void showStudentInfo(bool state)
        {
            pnlStudentInfo.Visible = state;
        }
        private void loadStudentInfo()
        {
            txtStudentCode.Text = _session.CurrentUser.Student.StudentCode;
            txtStudentClass.Text = _session.CurrentUser.Student.ClassName;
            txtMajor.Text = _session.CurrentUser.Student.MajorName;
            txtFaculty.Text = _session.CurrentUser.Student.FacultyName;
            txtSchoolYear.Text = _session.CurrentUser.Student.SchoolYear;
            txtGPA.Text = _session.CurrentUser.Student.GPA.ToString();
        }
        private void ucAccount_Load(object sender, EventArgs e)
        {
            loadUserInfo();
            if (_session.CheckRole("Student"))
            {
                showStudentInfo(true);
                loadStudentInfo();
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Utils.ShowMessages("Validation", "Email không được để trống", this.ParentForm!);
                txtEmail.Focus();
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+$"))
            {
                Utils.ShowMessages("Validation", "Email không đúng định dạng", this.ParentForm!);
                txtEmail.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Utils.ShowMessages("Validation", "Tên không được để trống", this.ParentForm!);
                txtName.Focus();
                return;
            }

            if (!DateOnly.TryParse(txtBirthday.Text, out DateOnly birthday))
            {
                Utils.ShowMessages("Validation", "Ngày sinh không hợp lệ", this.ParentForm!);
                txtBirthday.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtPhoneNumber.Text, @"^[0-9]{9,11}$"))
            {
                Utils.ShowMessages("Validation", "Số điện thoại không hợp lệ", this.ParentForm!);
                txtPhoneNumber.Focus();
                return;
            }

            var user = await _userService.GetById(_session.CurrentUser.Id);

            var editProfileDTO = new EditProfileDTO
            {
                FullName = txtName.Text,
                Birthday = birthday,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
            };

            await _userService.EditProfile(user, editProfileDTO);

            _session.SetCurrentUser(UserMapper.ToCurrentUserDTO(user));
            Utils.ShowMessages("Success", "Cập nhật thông tin thành công", this.ParentForm!);
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
