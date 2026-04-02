using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.EventDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Student.Appeal;
using QLDRL.Presentation.Student.Points;
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

namespace QLDRL.Presentation.Student.Events
{
    public partial class ucRegisteredEventItem : UserControl
    {
        private readonly Session _session;
        public EventRegistrationDTO regisDTO;
        private readonly IServiceProvider _serviceProvider;
        private readonly AppealService _appealService;
        public ucRegisteredEventItem(IServiceProvider serviceProvider, Session session, AppealService appealService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _session = session;
            _appealService = appealService;
        }
        private (string, Color) ConvertAttendStatus(AttendStatus status)
        {
            switch (status)
            {
                case AttendStatus.Processing:
                    return ("Đang xử lý", Color.Gold);
                case AttendStatus.Attended:
                    return ("Đã cộng điểm", Color.Green);
                case AttendStatus.NoAttended:
                    return ("Không cộng điểm", Color.Red);
                default:
                    return (status.ToString(), Color.Black);
            }
        }
        private void FillData()
        {
            lblEventName.Text = regisDTO.EventName;
            lblSemester.Text = regisDTO.SemesterName;
            lblRegisteredDate.Text = regisDTO.RegisteredDate;
            lblStartDate.Text = regisDTO.StartDate;
            lblEndDate.Text = regisDTO.EndDate;
            lblScore.Text = regisDTO.Score.ToString();
            var (status, color) = ConvertAttendStatus(regisDTO.AttendStatus);
            lblStatus.Text = status;
            lblStatus.BackColor = color;
        }
        private async void ucRegisteredEventItem_Load(object sender, EventArgs e)
        {
            FillData();
            btnAppeal.Visible = false;
            if (regisDTO.AttendStatus == AttendStatus.NoAttended)
            {
                btnAppeal.Visible = true;
            }
            await CheckAppealStatus();
        }
        private async Task CheckAppealStatus()
        {
            var studentAppeal = await _appealService.GetByStudentEvent(_session.CurrentUser!.Id, regisDTO.EventId);
            if(studentAppeal != null)
            {
                btnAppeal.Visible = true;
                btnAppeal.Text = "[Xem]";
                btnAppeal.Refresh();
            }
        }
        private async void btnAppeal_Click(object sender, EventArgs e)
        {
            var studentAppeal = await _appealService.GetByStudentEvent(_session.CurrentUser!.Id, regisDTO.EventId);
            if( studentAppeal == null )
            {
                if (_session.CurrentUser!.Student == null)
                {
                    Utils.ShowMessages("Lỗi", "Chỉ sinh viên mới được thực hiện thao tác này", this.ParentForm!);
                    return;
                }
                var appealForm = _serviceProvider.GetRequiredService<frmAppeal>();
                appealForm.eventId = regisDTO.EventId;
                appealForm.ShowDialog();
                await CheckAppealStatus();
            }
            else
            {
                var viewAppealForm = new frmViewAppeal();
                viewAppealForm.appeal = studentAppeal;
                viewAppealForm.ShowDialog();
            }
        }
    }
}
