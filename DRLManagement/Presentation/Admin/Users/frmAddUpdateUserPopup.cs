using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using QLDRL.DTOs.AdminDTOs;
using QLDRL.DTOs.ManagerDTOs;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Helpers.States;
using QLDRL.Models;
using QLDRL.Presentation.Admin.Dialogs.AddUpdateUser;
using QLDRL.Services;

namespace QLDRL.Presentation.Admin.Dialogs
{
    public partial class frmAddUpdateUserPopup : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserServices _userServices;
        private readonly StudentService _studentService;
        private readonly AdminService _adminService;
        private readonly ManagerService _managerService;
        private readonly OrganizerService _organizerService;
        private readonly RoleServices _roleServices;
        private readonly StudentClassService _studentClassService;
        public FormMode Mode;
        public CreateUpdateUserDTO? userDTO;
        private AddUserRoleState _state = new();

        public frmAddUpdateUserPopup(
            IServiceProvider serviceProvider,
            UserServices userServices,
            RoleServices roleServices,
            StudentService studentService,
            StudentClassService studentClassService,
            AdminService adminService,
            ManagerService managerService,
            OrganizerService organizerService)
        {
            InitializeComponent();
            
            _serviceProvider = serviceProvider;
            _userServices = userServices;
            _roleServices = roleServices;
            _studentClassService = studentClassService;
            _studentService = studentService;
            _adminService = adminService;
            _managerService = managerService;
            _organizerService = organizerService;
        }
        private async Task cboRoles_Load()
        {
            var roles = await _roleServices.GetAll();
            cboRoles.DisplayMember = "Name";
            cboRoles.ValueMember = "Id";
            cboRoles.DataSource = roles;
            cboRoles.SelectedIndex = 0;
        }
        private async Task loadRolesState()
        {
            var user = await _userServices.GetById(userDTO!.Id);
            var roles = await _userServices.GetRolesByUserId(user!.Id);
            _state.RoleIds.AddRange(roles.Select(r => r.Id));
            if (user.Admin != null)
            {
                var admin = user.Admin;

                _state.AdminDTO = new CreateUpdateAdminDTO
                {
                    UserId = admin.UserId,
                    IsSuperAdmin = admin.IsSuperAdmin,
                    Department = admin.Department
                };
            }

            if (user.Manager != null)
            {
                var manager = user.Manager;

                _state.ManagerDTO = new CreateUpdateManagerDTO
                {
                    UserId = manager.UserId,
                    ManagerCode = manager.ManagerCode,
                    Position = manager.Position,
                    Department = manager.Department,
                    FacultyName = manager.FacultyName,
                };
            }

            if (user.Organizer != null)
            {
                var organizer = user.Organizer;

                _state.OrganizerDTO = new CreateUpdateOrganizerDTO
                {
                    UserId = organizer.UserId,
                    ClubName = organizer.ClubName,
                    Position = organizer.Position
                };
            }

            if (user.Student != null)
            {
                var student = user.Student;

                _state.StudentDTO = new CreateUpdateStudentDTO
                {
                    StudentCode = student.StudentCode,
                    StudentClassId = student.StudentClass.Id,
                    EnrollmentYear = student.EnrollmentYear,
                    GraduationYear = student.GraduationYear,
                    GPA = student.GPA
                };
            }
        }

        private async void frmAddUserPopup_Load(object sender, EventArgs e)
        {
            if(Mode == FormMode.Update)
            {
                txtPassword.ReadOnly = true;
                txtPassword.Text = "000000000";
                txtPassword.UseSystemPasswordChar = true;
                await loadRolesState();
            }
            await cboRoles_Load();
            if (Mode == FormMode.Create)
                lblFormTitle.Text = "THÊM NGƯỜI DÙNG MỚI";
            else
            {
                lblFormTitle.Text = "CHỈNH SỬA THÔNG TIN";
                FillUserData();
            }
        }

        private void FillUserData()
        {
            txtEmail.Text = userDTO!.Email;
            txtFullName.Text = userDTO.FullName;
            txtBirthday.Text = userDTO.Birthday.ToString();
            txtPhoneNumber.Text = userDTO.PhoneNumber;
            txtAddress.Text = userDTO.Address;
        }
        private async Task<(int, ValidateUserResult)> createUser()
        {
            var userDTO = new CreateUpdateUserDTO
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                Birthday = txtBirthday.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RoleIds = _state.RoleIds
            };
            var validationResult = await _userServices.ValidateUser(userDTO);
            int id = 0;
            if (validationResult == ValidateUserResult.Success)
                id = await _userServices.Create(userDTO);
            return (id, validationResult);
        }
        private async Task<ValidateUserResult> updateUser()
        {
            var user = await _userServices.GetById(userDTO!.Id);
            var updateUserDTO = new CreateUpdateUserDTO
            {
                Id = userDTO.Id,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                Birthday = txtBirthday.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Address = txtAddress.Text,
                RoleIds = _state.RoleIds
            };
            var validationResult = await _userServices.ValidateUser(updateUserDTO);
            if (validationResult == ValidateUserResult.Success)
                await _userServices.Update(user, updateUserDTO);
            return validationResult;
        }
        private async Task<ValidateStudentResult> createStudent(int? userId)
        {
            var user = await _userServices.GetById(userId);
            var studentClass = await _studentClassService.GetById(_state.StudentDTO!.StudentClassId);

            var validationResult = _studentService.ValidateStudent(_state.StudentDTO, studentClass!);
            if (validationResult == ValidateStudentResult.Success)
                await _studentService.Create(_state.StudentDTO, user!);
            return validationResult;
        }
        private async Task<ValidateStudentResult> updateStudent(int userId)
        {
            var user = await _studentService.GetById(userId);
            var studentClass = await _studentClassService.GetById(_state.StudentDTO!.StudentClassId);
            var validationResult = _studentService.ValidateStudent(_state.StudentDTO, studentClass!);
            if(validationResult == ValidateStudentResult.Success)
                await _studentService.Update(user!, _state.StudentDTO);
            return validationResult;
        }

        private async Task<ValidateAdminResult> createAdmin(int? userId)
        {
            var user = await _userServices.GetById(userId);

            var validationResult = _adminService.ValidateAdmin(_state.AdminDTO);
            if (validationResult == ValidateAdminResult.Success)
                await _adminService.Create(_state.AdminDTO, user);

            return validationResult;
        }

        private async Task<ValidateAdminResult> updateAdmin(int? userId)
        {
            var admin = await _adminService.GetById(userId);

            var validationResult = _adminService.ValidateAdmin(_state.AdminDTO);
            if (validationResult == ValidateAdminResult.Success)
                await _adminService.Update(admin, _state.AdminDTO);

            return validationResult;
        }

        private async Task<ValidateManagerResult> createManager(int? userId)
        {
            var user = await _userServices.GetById(userId);

            var validationResult = _managerService.ValidateManager(_state.ManagerDTO);
            if (validationResult == ValidateManagerResult.Success)
                await _managerService.Create(_state.ManagerDTO, user);

            return validationResult;
        }

        private async Task<ValidateManagerResult> updateManager(int? userId)
        {
            var manager = await _managerService.GetById(userId);

            var validationResult = _managerService.ValidateManager(_state.ManagerDTO);
            if (validationResult == ValidateManagerResult.Success)
                await _managerService.Update(manager, _state.ManagerDTO);

            return validationResult;
        }

        private async Task<ValidateOrganizerResult> createOrganizer(int? userId)
        {
            var user = await _userServices.GetById(userId);

            var validationResult = _organizerService.ValidateOrganizer(_state.OrganizerDTO);
            if (validationResult == ValidateOrganizerResult.Success)
                await _organizerService.Create(_state.OrganizerDTO, user);

            return validationResult;
        }

        private async Task<ValidateOrganizerResult> updateOrganizer(int? userId)
        {
            var organizer = await _organizerService.GetById(userId);

            var validationResult = _organizerService.ValidateOrganizer(_state.OrganizerDTO);
            if (validationResult == ValidateOrganizerResult.Success)
                await _organizerService.Update(organizer, _state.OrganizerDTO);

            return validationResult;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            ValidateUserResult validationResult;
            int id = 0;

            var studentRoleId = Convert.ToInt32(RoleType.Student);
            var adminRoleId = Convert.ToInt32(RoleType.Admin);
            var managerRoleId = Convert.ToInt32(RoleType.Manager);
            var organizerRoleId = Convert.ToInt32(RoleType.Organizer);

            if (Mode == FormMode.Create)
            {
                (id, validationResult) = await createUser();

                if (validationResult == ValidateUserResult.Success)
                {
                    if (_state.RoleIds.Contains(adminRoleId))
                    {
                        await createAdmin(id);
                    }

                    if (_state.RoleIds.Contains(managerRoleId))
                    {
                        await createManager(id);
                    }

                    if (_state.RoleIds.Contains(organizerRoleId))
                    {
                        await createOrganizer(id);
                    }

                    if (_state.RoleIds.Contains(studentRoleId))
                    {
                        await createStudent(id);
                    }
                }
            }
            else
            {
                validationResult = await updateUser();

                if (validationResult == ValidateUserResult.Success)
                {
                    if (_state.RoleIds.Contains(adminRoleId))
                    {
                        if (userDTO.RoleIds.Contains(adminRoleId))
                            await updateAdmin(userDTO.Id);
                        else
                            await createAdmin(userDTO.Id);
                    }
                    else
                    {
                        await _adminService.Delete(userDTO.Id);
                    }

                    if (_state.RoleIds.Contains(managerRoleId))
                    {
                        if (userDTO.RoleIds.Contains(managerRoleId))
                            await updateManager(userDTO.Id);
                        else
                            await createManager(userDTO.Id);
                    }
                    else
                    {
                        await _managerService.Delete(userDTO.Id);
                    }

                    if (_state.RoleIds.Contains(organizerRoleId))
                    {
                        if (userDTO.RoleIds.Contains(organizerRoleId))
                            await updateOrganizer(userDTO.Id);
                        else
                            await createOrganizer(userDTO.Id);
                    }
                    else
                    {
                        await _organizerService.Delete(userDTO.Id);
                    }

                    if (_state.RoleIds.Contains(studentRoleId))
                    {
                        if (userDTO.RoleIds.Contains(studentRoleId))
                            await updateStudent(userDTO.Id!.Value);
                        else
                            await createStudent(userDTO.Id);
                    }
                    else
                    {
                        await _studentService.Delete(userDTO.Id!.Value);
                    }
                }
            }
            switch (validationResult)
            {
                case ValidateUserResult.EmptyEmail:
                    Utils.ShowMessages("Lỗi xác thực", "Email không được để trống", this);
                    txtEmail.Focus();
                    break;

                case ValidateUserResult.InvalidEmail:
                    Utils.ShowMessages("Lỗi xác thực", "Email không đúng định dạng", this);
                    txtEmail.Focus();
                    break;

                case ValidateUserResult.ExistedEmail:
                    Utils.ShowMessages("Lỗi xác thực", "Email này đã tồn tại", this);
                    txtEmail.Focus();
                    break;

                case ValidateUserResult.EmptyName:
                    Utils.ShowMessages("Lỗi xác thực", "Tên không được để trống", this);
                    txtFullName.Focus();
                    break;

                case ValidateUserResult.InvalidBirthday:
                    Utils.ShowMessages("Lỗi xác thực", "Ngày sinh không hợp lệ", this);
                    txtBirthday.Focus();
                    break;

                case ValidateUserResult.InvalidPhoneNumber:
                    Utils.ShowMessages("Lỗi xác thực", "Số điện thoại không hợp lệ", this);
                    txtPhoneNumber.Focus();
                    break;

                case ValidateUserResult.EmptyPassword:
                    Utils.ShowMessages("Lỗi xác thực", "Mật khẩu không được để trống", this);
                    txtPassword.Focus();
                    break;

                case ValidateUserResult.ShortPassword:
                    Utils.ShowMessages("Lỗi xác thực", "Mật khẩu phải ít nhất 5 ký tự", this);
                    txtPassword.Focus();
                    break;

                case ValidateUserResult.NoRoleSelected:
                    Utils.ShowMessages("Lỗi xác thực", "Người dùng phải có ít nhất một vai trò", this);
                    cboRoles.Focus();
                    break;

                case ValidateUserResult.Success:
                    if(Mode == FormMode.Create)
                        Utils.ShowMessages("Thành công", "Tạo người dùng thành công", this);
                    else
                        Utils.ShowMessages("Thành công", "Cập nhật người dùng thành công", this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    if(Mode == FormMode.Update)
                    {
                        var user = await _userServices.GetById(userDTO.Id);
                    }
                    break;
                default:
                    Utils.ShowMessages("Lỗi", "Thao tác không hợp lệ", this);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var roleId = (RoleType)Convert.ToInt32(cboRoles.SelectedValue);
            if (roleId == RoleType.Admin)
            {
                var uc = _serviceProvider.GetRequiredService<ucAdminForm>();
                uc.State = _state;
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(uc);
            }

            if (roleId == RoleType.Manager)
            {
                var uc = _serviceProvider.GetRequiredService<ucManagerForm>();
                uc.State = _state;
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(uc);
            }

            if (roleId == RoleType.Organizer)
            {
                var uc = _serviceProvider.GetRequiredService<ucOrganizerForm>();
                uc.State = _state;
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(uc);
            }
            if (roleId == RoleType.Student)
            {
                var uc = _serviceProvider.GetRequiredService<ucStudentForm>();
                uc.State = _state;
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(uc);
            }
        }

        private void frmAddUpdateUserPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            _state.RoleIds.Clear();
            _state.StudentDTO = null;
        }
    }
}
