using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Admin.Dialogs;
using QLDRL.Services;
using System.Threading.Tasks;

namespace QLDRL.Presentation.Admin
{
    public partial class ucUsers : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserServices _userServices;
        public ucUsers(IServiceProvider serviceProvider, UserServices userServices)
        {
            _userServices = userServices;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }
        private async Task loadUserData(string search = "")
        {
            var users = string.IsNullOrWhiteSpace(search)
                ? await _userServices.GetByStatus(true)
                : await _userServices.SearchUsers(search);
            var usersDTO = UserMapper.ToUserDTOList(users);
            dgvUsers.DataSource = usersDTO;
        }
        private async void ucUsers_Load(object sender, EventArgs e)
        {
            await loadUserData();
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var addUserPopup = _serviceProvider.GetRequiredService<frmAddUpdateUserPopup>();
            addUserPopup.Mode = FormMode.Create;
            var dialogResult = addUserPopup.ShowDialog();
            if (dialogResult == DialogResult.OK)
                await loadUserData();
        }

        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var updateUserPopup = _serviceProvider.GetRequiredService<frmAddUpdateUserPopup>();
            updateUserPopup.Mode = FormMode.Update;
            var id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            var user = await _userServices.GetById(id);
            var userDTO = new CreateUpdateUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Birthday = user.Birthday.ToString(),
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleIds = user.Roles.Select(x => x.Id).ToList()
            };
            updateUserPopup.userDTO = userDTO;
            var dialogResult = updateUserPopup.ShowDialog();
            if (dialogResult == DialogResult.OK)
                await loadUserData();
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
                Utils.ShowMessages("Thông báo", "Vui lòng chọn người dùng", this.ParentForm!);
            else
            {
                var dialogResult = Utils.ConfirmDialog("Xóa người dùng", "Bạn có chắc chắn muốn xóa người dùng này?", this.ParentForm!);
                if (dialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
                    await _userServices.SoftDelete(id);
                    Utils.ShowMessages("Thông báo", "Xóa người dùng thành công", this.ParentForm!);
                    await loadUserData();
                }
            }
        }

        private async void btnViewProfile_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);
            var user = await _userServices.GetById(id);
            var userDTO = UserMapper.ToUserDTO(user);
            var userProfile = _serviceProvider.GetRequiredService<frmViewProfile>();
            userProfile.userDTO = userDTO;
            userProfile.ShowDialog();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await loadUserData(txtSearchBar.Text);
        }

        private void txtSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
