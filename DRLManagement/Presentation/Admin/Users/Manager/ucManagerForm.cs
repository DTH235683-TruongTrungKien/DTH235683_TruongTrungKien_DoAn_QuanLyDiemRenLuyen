using QLDRL.DTOs.ManagerDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Helpers.States;
using QLDRL.Services;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace QLDRL.Presentation.Admin.Dialogs.AddUpdateUser
{
    public partial class ucManagerForm : UserControl
    {
        public AddUserRoleState State;
        private readonly int RoleId = Convert.ToInt32(RoleType.Manager);
        private readonly ManagerService _managerService;

        public ucManagerForm(ManagerService managerService)
        {
            InitializeComponent();
            _managerService = managerService;
        }

        private void ucManagerForm_Load(object sender, EventArgs e)
        {
            if (State.ManagerDTO != null)
                FillData(false);
        }

        private void FillData(bool isBlank)
        {
            if (isBlank)
            {
                txtManagerCode.Text = "";
                txtPosition.Text = "";
                txtDepartment.Text = "";
                txtFaculty.Text = "";
            }
            else
            {
                txtManagerCode.Text = State.ManagerDTO.ManagerCode;
                txtPosition.Text = State.ManagerDTO.Position;
                txtDepartment.Text = State.ManagerDTO.Department;
                txtFaculty.Text = State.ManagerDTO.FacultyName;
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var dto = new CreateUpdateManagerDTO
            {
                ManagerCode = txtManagerCode.Text,
                Position = txtPosition.Text,
                Department = txtDepartment.Text,
                FacultyName = txtFaculty.Text,
            };

            var result = _managerService.ValidateManager(dto);

            switch (result)
            {
                case ValidateManagerResult.EmptyCode:
                    Utils.ShowMessages("Lỗi", "Mã không hợp lệ", this.ParentForm!);
                    break;

                case ValidateManagerResult.EmptyPosition:
                    Utils.ShowMessages("Lỗi", "Chức vụ không được để trống", this.ParentForm!);
                    break;

                case ValidateManagerResult.EmptyDepartment:
                    Utils.ShowMessages("Lỗi", "Phòng ban không được để trống", this.ParentForm!);
                    break;

                case ValidateManagerResult.InvalidFaculty:
                    Utils.ShowMessages("Lỗi", "Khoa không hợp lệ", this.ParentForm!);
                    break;

                case ValidateManagerResult.Success:
                    if (!State.RoleIds.Contains(RoleId))
                        State.RoleIds.Add(RoleId);

                    State.ManagerDTO = dto;
                    Utils.ShowMessages("Thành công", "Cập nhật vai trò thành công", this.ParentForm!);
                    break;
            }
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            if (!State.RoleIds.Contains(RoleId))
            {
                Utils.ShowMessages("Lỗi", "Vai trò chưa tồn tại", this.ParentForm!);
                return;
            }

            State.RoleIds.Remove(RoleId);
            State.ManagerDTO = null;
            FillData(true);

            Utils.ShowMessages("Thành công", "Gỡ bỏ vai trò thành công", this.ParentForm!);
        }
    }
}