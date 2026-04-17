using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Enums;
using QLDRL.Models;
using QLDRL.Services;

namespace QLDRL.Presentation.Manager.Confirms
{
    public partial class frmConfirmDetail : Form
    {
        private readonly ConfirmService _confirmService;
        private readonly IServiceProvider _serviceProvider;
        public Confirm confirm;
        public frmConfirmDetail(ConfirmService confirmService, PointCategoryService pointCategoryService, StudentService studentService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _confirmService = confirmService;
            _serviceProvider = serviceProvider;
        }
        private void FillValue()
        {
            var student = confirm.Student;
            txtStudent.Text = student.User.FullName + " - " + student.StudentCode + " - " + student.StudentClass.Name;
            txtSemester.Text = confirm.Semester.Name;
            txtReason.Text = confirm.Reason;
        }

        private void frmConfirmDetail_Load(object sender, EventArgs e)
        {
            CheckConfirmStatus();
            FillValue();
        }
        private void CheckConfirmStatus()
        {
            if (confirm.Status != ConfirmStatus.Pending)
            {
                btnVerify.Enabled = false;
                btnReject.Enabled = false;
            }
            if (confirm.Status != ConfirmStatus.Approved)
            {
                btnPrint.Enabled = false;
            }
            btnVerify.Refresh();
            btnReject.Refresh();
            btnPrint.Refresh();
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            await _confirmService.UpdateStatus(confirm, ConfirmStatus.Approved);
            CheckConfirmStatus();
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            await _confirmService.UpdateStatus(confirm, ConfirmStatus.Rejected);
            CheckConfirmStatus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var printConfirmForm = _serviceProvider.GetRequiredService<frmPrintConfirm>();
            printConfirmForm.confirm = confirm;
            printConfirmForm.ShowDialog();
        }
    }
}
