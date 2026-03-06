using QLDRL.DTOs.AdminDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Helpers.States;
using QLDRL.Services;

namespace QLDRL.Presentation.Admin.Dialogs.AddUpdateUser
{
    public partial class ucAdminForm : UserControl
    {
        public AddUserRoleState State;
        private readonly int RoleId = Convert.ToInt32(RoleType.Admin);
        private readonly AdminService _adminService;

        public ucAdminForm(AdminService adminService)
        {
            InitializeComponent();
            _adminService = adminService;
        }

        private void ucAdminForm_Load(object sender, EventArgs e)
        {
            if (State.AdminDTO != null)
                FillData(false);
        }

        private void FillData(bool isBlank)
        {
            if (isBlank)
            {
                txtDepartment.Text = "";
                chkIsSuperAdmin.Checked = false;
            }
            else
            {
                txtDepartment.Text = State.AdminDTO.Department;
                chkIsSuperAdmin.Checked = State.AdminDTO.IsSuperAdmin;
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var dto = new CreateUpdateAdminDTO
            {
                Department = txtDepartment.Text,
                IsSuperAdmin = chkIsSuperAdmin.Checked
            };

            var result = _adminService.ValidateAdmin(dto);

            switch (result)
            {
                case ValidateAdminResult.EmptyDepartment:
                    Utils.ShowMessages("Lỗi", "Phòng ban không được để trống", this.ParentForm!);
                    break;

                case ValidateAdminResult.Success:
                    if (!State.RoleIds.Contains(RoleId))
                        State.RoleIds.Add(RoleId);

                    State.AdminDTO = dto;
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
            State.AdminDTO = null;
            FillData(true);

            Utils.ShowMessages("Thành công", "Gỡ bỏ vai trò thành công", this.ParentForm!);
        }
    }
}