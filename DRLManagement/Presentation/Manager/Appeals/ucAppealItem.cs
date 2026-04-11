using Microsoft.Extensions.DependencyInjection;
using QLDRL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Presentation.Manager.Appeals
{
    public partial class ucAppealItem : UserControl
    {
        public Models.Appeal appeal;
        private readonly IServiceProvider _serviceProvider;
        public ucAppealItem(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private (string, Color) ConvertAppealStatus(AppealStatus status)
        {
            switch (status)
            {
                case AppealStatus.Pending:
                    return ("Đang chờ", Color.Gold);
                case AppealStatus.Approved:
                    return ("Đã xử lý", Color.Green);
                case AppealStatus.Rejected:
                    return ("Bị từ chối", Color.Red);
                default:
                    return (status.ToString(), Color.Black);
            }
        }
        private void FillData()
        {
            var student = appeal.Student;
            lblStudent.Text = student.User.FullName + " - " + student.StudentCode + " - " + student.StudentClass.Name;
            lblEventName.Text = appeal.Event.Name;
            var (status, color) = ConvertAppealStatus(appeal.Status);
            lblStatus.Text = status;
            lblStatus.BackColor = color;
        }
        private void ucAppealItem_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnViewAppeal_Click(object sender, EventArgs e)
        {
            var appealDetailForm = _serviceProvider.GetRequiredService<frmAppealDetail>();
            appealDetailForm.appeal = appeal;
            appealDetailForm.ShowDialog();
        }
    }
}
