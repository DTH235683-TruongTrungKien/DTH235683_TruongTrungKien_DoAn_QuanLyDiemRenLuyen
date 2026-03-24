using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Presentation.Admin.Dialogs;
using QLDRL.Services;

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
        private async Task loadUserData()
        {
            var users = await _userServices.GetAll();
            var usersDTO = UserMapper.ToUserDTOList(users);
            dgvUsers.DataSource = usersDTO;
        }
        private async void ucUsers_Load(object sender, EventArgs e)
        {
            await loadUserData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var addUserPopup = _serviceProvider.GetRequiredService<frmAddUserPopup>();
            addUserPopup.ShowDialog();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var updateUserPopup = _serviceProvider.GetRequiredService<frmUpdateUserPopup>();
            updateUserPopup.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {

        }
    }
}
