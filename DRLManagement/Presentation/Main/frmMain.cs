using QLDRL.Services;
using QLDRL.Forms.Admin;
using QLDRL.Forms.Manager;
using QLDRL.Forms.Student;
using DRLManagement;
using QLDRL.Presentation.Main;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Presentation.Admin;
using QLDRL.Helpers.States;

namespace QLDRL.Forms.Main
{
    public partial class frmMain : Form
    {
        private readonly Session _session;
        private readonly IServiceProvider _serviceProvider;
        public frmMain(Session session, UserServices userService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _session = session;
            _session.OnUserChanged += (user) =>
            {
                lblUsername.Text = user.FullName;
            };
            _serviceProvider = serviceProvider;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            var user = _session.CurrentUser;
            sidebar_Load(user);
            ucAccount_Load();   
        }
        private void sidebar_Load(CurrentUserDTO user)
        {
            if (user != null)
            {
                lblUsername.Text = user.FullName;
                int yAxis = 246;
                if (user.RoleNames.Contains("Admin"))
                {
                    var adminPanel = new ucAdminPanel();
                    adminPanel.ucUsers_Load += ucUsers_Load;
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
            var ucAccount = _serviceProvider.GetRequiredService<ucAccount>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucAccount);
        }

        private void ucSettings_Load()
        {

        }
        public void ucUsers_Load()
        {
            var ucUsers = _serviceProvider.GetRequiredService<ucUsers>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucUsers);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _session.SetCurrentUser(null);
            Close();
        }
        private void btnAccount_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnAccount);
            ucAccount_Load();
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnSetting);
        }
    }
}
