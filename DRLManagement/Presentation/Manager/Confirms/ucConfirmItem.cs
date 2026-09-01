using Microsoft.Extensions.DependencyInjection;
using QLDRL.Enums;
using QLDRL.Models;

namespace QLDRL.Presentation.Manager.Confirms
{
    public partial class ucConfirmItem : UserControl
    {
        public Confirm confirm;
        private readonly IServiceProvider _serviceProvider;
        public ucConfirmItem(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private (string, Color) ConvertConfirmStatus(ConfirmStatus status)
        {
            switch (status)
            {
                case ConfirmStatus.Pending:
                    return ("Đang chờ", Color.Gold);
                case ConfirmStatus.Approved:
                    return ("Đã xử lý", Color.Green);
                case ConfirmStatus.Rejected:
                    return ("Bị từ chối", Color.Red);
                default:
                    return (status.ToString(), Color.Black);
            }
        }
        private void FillData()
        {
            var student = confirm.Student;
            var (status, color) = ConvertConfirmStatus(confirm.Status);
            lblStatus.Text = status;
            lblStatus.BackColor = color;
            lblSemester.Text = confirm.Semester.Name;
            lblStudent.Text = student.User.FullName + " - " + student.StudentCode + " - " + student.StudentClass.Name;
        }

        private void ucConfirmItem_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            var confirmDetailForm = _serviceProvider.GetRequiredService<frmConfirmDetail>();
            confirmDetailForm.confirm = confirm;
            confirmDetailForm.ShowDialog();
        }
    }
}
