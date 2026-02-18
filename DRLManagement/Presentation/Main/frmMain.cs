using QLDRL.Services;
using QLDRL.Forms.Admin;
using QLDRL.Forms.Manager;
using QLDRL.Forms.Student;
using QLDRL.Presentation.Main;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Presentation.Admin;
using QLDRL.Helpers.States;
using QLDRL.Presentation.Manager.PointCategory;
using QLDRL.Presentation.Student;
using QLDRL.Presentation.Organizer;
using QLDRL.Presentation.Manager.EventManagement;
using QLDRL.Enums;
using QLDRL.Presentation.Manager.Appeals;
using QLDRL.Presentation.Student.Confirms;
using QLDRL.Presentation.Manager.Confirms;
using QLDRL.Presentation.Admin.DataBackup;

namespace QLDRL.Forms.Main
{
    public partial class frmMain : Form
    {
        private readonly Session _session;
        private readonly IServiceProvider _serviceProvider;
        private readonly EventService _eventService;
        public frmMain(Session session, UserServices userService, IServiceProvider serviceProvider, EventService eventService)
        {
            InitializeComponent();
            _session = session;
            _session.OnUserChanged += (user) =>
            {
                lblUsername.Text = user.FullName;
            };
            _serviceProvider = serviceProvider;
            _eventService = eventService;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (_session.IsAuthenticated == false)
                return;
            var user = _session.CurrentUser;
            sidebar_Load(user);
            ucAccount_Load();
            StartEventStatusTimer();
        }
        private void sidebar_Load(CurrentUserDTO user)
        {
            if (user != null)
            {
                lblUsername.Text = user.FullName;
                if (user.RoleNames.Contains("Admin"))
                {
                    var adminPanel = new ucAdminPanel();
                    adminPanel.ucUsers_Load += ucUsers_Load;
                    adminPanel.ucBackup_Load += ucBackup_Load;
                    flpSidebar.Controls.Add(adminPanel);
                }
                if (user.RoleNames.Contains("Manager"))
                {
                    var managerPanel = new ucManagerPanel();
                    managerPanel.ucPointCategories_Load += ucPointCategories_Load;
                    managerPanel.ucPendingEvents_Load += ucPendingEvents_Load;
                    managerPanel.ucAppeals_Load += ucAppeals_Load;
                    managerPanel.ucConfirmManagement_Load += ucConfirmManagement_Load;
                    flpSidebar.Controls.Add(managerPanel);
                }
                if (user.RoleNames.Contains("Organizer"))
                {
                    var organizerPanel = new ucOrganizerPanel();
                    organizerPanel.ucEventManagement += ucEventManagement_Load;
                    flpSidebar.Controls.Add(organizerPanel);
                }
                if (user.RoleNames.Contains("Student"))
                {
                    var studentPanel = new ucStudentPanel();
                    studentPanel.ucPoints_Load += ucPointPreview_Load;
                    studentPanel.ucEvents_Load += ucEvents_Load;
                    studentPanel.ucConfirms_Load += ucConfirms_Load;
                    flpSidebar.Controls.Add(studentPanel);
                }
            }
        }

        //General
        private void ucAccount_Load()
        {
            var ucAccount = _serviceProvider.GetRequiredService<ucAccount>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucAccount);
        }

        //Admin
        public void ucUsers_Load()
        {
            var ucUsers = _serviceProvider.GetRequiredService<ucUsers>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucUsers);
        }
        public void ucBackup_Load()
        {
            var ucBackup = _serviceProvider.GetRequiredService<ucBackup>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucBackup);
        }

        //Manager
        public void ucPointCategories_Load()
        {
            var ucPointCategories = _serviceProvider.GetRequiredService<ucPointCategories>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucPointCategories);
        }
        public void ucPendingEvents_Load()
        {
            var ucPendingEvents = _serviceProvider.GetRequiredService<ucPendingEvents>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucPendingEvents);
        }
        public void ucAppeals_Load()
        {
            var ucAppeals = _serviceProvider.GetRequiredService<ucAppeals>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucAppeals);
        }
        public void ucConfirmManagement_Load()
        {
            var ucConfirmManagement = _serviceProvider.GetRequiredService<ucConfirmManagement>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucConfirmManagement);
        }
        //Organizer
        public void ucEventManagement_Load()
        {
            var ucEventManagement = _serviceProvider.GetRequiredService<ucEventManagement>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucEventManagement);
        }

        //Student
        public void ucEvents_Load()
        {
            var ucEvents = _serviceProvider.GetRequiredService<ucEvents>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucEvents);
        }
        public void ucPointPreview_Load()
        {
            var ucPointPreview = _serviceProvider.GetRequiredService<ucPoints>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucPointPreview);
        }
        public void ucConfirms_Load()
        {
            var ucConfirms = _serviceProvider.GetRequiredService<ucConfirms>();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(ucConfirms);
        }

        // General
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
        private System.Windows.Forms.Timer _timer;
        public void StartEventStatusTimer()
        {
            if (_timer != null) return;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 60000;

            _timer.Tick += async (s, e) =>
            {
                await _eventService.UpdateEventStatus();
            };
                
            _timer.Start();
        }
    }
}
