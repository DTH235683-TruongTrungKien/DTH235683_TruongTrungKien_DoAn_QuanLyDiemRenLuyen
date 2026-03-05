using QLDRL.Helpers;
using QLDRL.Services;
using QLDRL.Forms.Admin;
using QLDRL.Forms.Manager;
using QLDRL.Forms.Student;
using DRLManagement;
using QLDRL.Presentation.Main;
using Microsoft.Extensions.DependencyInjection;

namespace QLDRL.Forms.Main
{
    public partial class frmMain : Form
    {
        private readonly Session _session;
        private readonly UserService _userService;
        public frmMain(Session session, UserService userService)
        {
            InitializeComponent();
            _session = session;
            _userService = userService;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            var user = _session.CurrentUser;
            ucAccount_Load();
            if (user != null)
            {
                lblUsername.Text = user.Name;
                int yAxis = 246;
                if (user.RoleNames.Contains("Admin"))
                {
                    var adminPanel = new ucAdminPanel();
                    adminPanel.Location = new Point(0, yAxis);
                    pnlMenu.Controls.Add(adminPanel);
                    yAxis += 187;
                }
                if (user.RoleNames.Contains("Manager"))
                {
                    var managerPanel = new ucManagerPanel();
                    managerPanel.Location = new Point(0, yAxis);
                    pnlMenu.Controls.Add(managerPanel);
                    yAxis += 406;
                }
                if (user.RoleNames.Contains("Organizer"))
                {
                    var organizerPanel = new ucOrganizerPanel();
                    organizerPanel.Location = new Point(0, yAxis);
                    pnlMenu.Controls.Add(organizerPanel);
                    yAxis += 200;
                }
                if (user.RoleNames.Contains("Student"))
                {
                    var studentPanel = new ucStudentPanel();
                    studentPanel.Location = new Point(0, yAxis);
                    pnlMenu.Controls.Add(studentPanel);
                }
            }
        }

        private void ucAccount_Load()
        {
            MenuState.SetButtonState(btnAccount);
            var ucAccount = Program.ServiceProvider.GetRequiredService<ucAccount>();
            pnlContent.Controls.Add(ucAccount);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _session.CurrentUser = null;
            Close();
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnAccount);
            
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnSetting);
        }
    }
}
