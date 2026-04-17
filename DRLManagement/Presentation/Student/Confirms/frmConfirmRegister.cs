using QLDRL.Enums;
using QLDRL.Models;
using QLDRL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Presentation.Student.Confirms
{
    public partial class frmConfirmRegister : Form
    {
        private readonly Session _session;
        private readonly ConfirmService _confirmService;
        private readonly SemesterService _semesterService;
        public frmConfirmRegister(Session session, ConfirmService confirmService, SemesterService semesterService)
        {
            InitializeComponent();
            _session = session;
            _confirmService = confirmService;
            _semesterService = semesterService;
        }
        private async Task FillData()
        {
            var semesters = await _semesterService.GetAll();
            cboSemesters.ValueMember = "Id";
            cboSemesters.DisplayMember = "Name";
            cboSemesters.DataSource = semesters;
            cboSemesters.SelectedIndex = 0;
        }
        private async void frmConfirmRegister_Load(object sender, EventArgs e)
        {
            await FillData();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var confirm = new Confirm
            {
                Reason = txtReason.Text,
                RegisteredDate = DateTime.Now,
                Status = ConfirmStatus.Pending,
                SemesterId = cboSemesters.SelectedIndex,
                StudentUserId = _session.CurrentUser!.Id

            };
            await _confirmService.Create(confirm);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
