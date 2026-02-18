using QLDRL.Helpers.States;

namespace QLDRL.Forms.Student
{
    public partial class ucStudentPanel : UserControl
    {
        public event Action ucPoints_Load;
        public event Action ucEvents_Load;
        public event Action ucConfirms_Load;
        public ucStudentPanel()
        {
            InitializeComponent();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnPoints);
            ucPoints_Load?.Invoke();
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnEvent);
            ucEvents_Load?.Invoke();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnConfirm);
            ucConfirms_Load?.Invoke();
        }
    }
}
