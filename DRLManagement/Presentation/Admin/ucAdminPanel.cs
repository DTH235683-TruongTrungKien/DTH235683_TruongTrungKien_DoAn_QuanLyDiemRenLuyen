using QLDRL.Helpers.States;

namespace QLDRL.Forms.Admin
{
    public partial class ucAdminPanel : UserControl
    {
        public event Action ucUsers_Load;
        public ucAdminPanel()
        {
            InitializeComponent();
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnUser);
            ucUsers_Load?.Invoke();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnControl);
        }
    }
}
