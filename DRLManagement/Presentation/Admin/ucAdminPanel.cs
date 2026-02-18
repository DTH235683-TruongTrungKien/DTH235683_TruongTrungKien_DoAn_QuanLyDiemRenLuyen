using QLDRL.Helpers.States;

namespace QLDRL.Forms.Admin
{
    public partial class ucAdminPanel : UserControl
    {
        public event Action ucUsers_Load;
        public event Action ucBackup_Load;
        public ucAdminPanel()
        {
            InitializeComponent();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnUser);
            ucUsers_Load?.Invoke();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnBackup);
            ucBackup_Load?.Invoke();
        }
    }
}
