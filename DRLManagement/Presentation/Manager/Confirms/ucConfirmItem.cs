using Microsoft.Extensions.DependencyInjection;
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
        private void FillData()
        {
            var student = confirm.Student;
            lblStatus.Text = "";
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
