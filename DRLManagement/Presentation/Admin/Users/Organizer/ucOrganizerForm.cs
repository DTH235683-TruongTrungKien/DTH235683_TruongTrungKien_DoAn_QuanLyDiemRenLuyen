using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Helpers.States;
using QLDRL.Services;

namespace QLDRL.Presentation.Admin.Dialogs.AddUpdateUser
{
    public partial class ucOrganizerForm : UserControl
    {
        public AddUserRoleState State;
        private readonly int RoleId = Convert.ToInt32(RoleType.Organizer);
        private readonly OrganizerService _organizerService;

        public ucOrganizerForm(OrganizerService organizerService)
        {
            InitializeComponent();
            _organizerService = organizerService;
        }

        private void ucOrganizerForm_Load(object sender, EventArgs e)
        {
            if (State.OrganizerDTO != null)
                FillData(false);
        }

        private void FillData(bool isBlank)
        {
            if (isBlank)
            {
                txtClubName.Text = "";
                txtPosition.Text = "";
            }
            else
            {
                txtClubName.Text = State.OrganizerDTO.ClubName;
                txtPosition.Text = State.OrganizerDTO.Position;
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var dto = new CreateUpdateOrganizerDTO
            {
                ClubName = txtClubName.Text,
                Position = txtPosition.Text
            };

            var result = _organizerService.ValidateOrganizer(dto);

            switch (result)
            {
                case ValidateOrganizerResult.EmptyClubName:
                    Utils.ShowMessages("Lỗi", "Tên CLB không được để trống", this.ParentForm!);
                    break;

                case ValidateOrganizerResult.EmptyPosition:
                    Utils.ShowMessages("Lỗi", "Chức vụ không được để trống", this.ParentForm!);
                    break;

                case ValidateOrganizerResult.Success:
                    if (!State.RoleIds.Contains(RoleId))
                        State.RoleIds.Add(RoleId);

                    State.OrganizerDTO = dto;
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
            State.OrganizerDTO = null;
            FillData(true);

            Utils.ShowMessages("Thành công", "Gỡ bỏ vai trò thành công", this.ParentForm!);
        }
    }
}