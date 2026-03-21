using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.EventDTOs;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Organizer.EventManagement;
using QLDRL.Presentation.Student.Events;
using QLDRL.Services;

namespace QLDRL.Presentation.Organizer
{
    public partial class frmEventDetail : Form
    {
        public EventDTO eventDTO;
        private readonly Session _session;
        private readonly EventService _eventService;
        private readonly EvidenceService _evidenceService;
        private readonly IServiceProvider _serviceProvider;
        public frmEventDetail(Session session, EventService eventService, EvidenceService evidenceService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _session = session;
            _eventService = eventService;
            _evidenceService = evidenceService;
            _serviceProvider = serviceProvider;
        }
        private void FillData()
        {
            lblEventName.Text = eventDTO.Name;
            txtDescription.Text = eventDTO.Description;

            pbEventImage.Image = Image.FromFile(Utils.FillImage(eventDTO.ImagePath));

            txtOrganizationUnit.Text = eventDTO.OrganizationUnit;
            txtLocation.Text = eventDTO.Location;

            dtpStartDate.Value = eventDTO.StartDate;
            dtpEndDate.Value = eventDTO.EndDate;
            lblRegistrationEnd.Text = eventDTO.RegistrationExpired.ToString();

            txtSemester.Text = eventDTO.SemesterName;
            txtPointCategory.Text = eventDTO.PointCategory;

            txtAddPoint.Text = "+" + eventDTO.AddPoint.ToString();
            txtRemovePoint.Text = "-" + eventDTO.RemovePoint;
            txtAmount.Text = eventDTO.RegisteredAmount.ToString() + "/" + eventDTO.TargetedAmount.ToString();

            txtAllowFaculties.Text = eventDTO.AllowFaculties;
            txtAllowClasses.Text = eventDTO.AllowClasses;
        }
        private void ShowRegisterButton(bool state)
        {
            if (state)
            {
                btnEventRegister.Visible = true;
                btnUnregister.Visible = false;
            }
            else
            {
                btnEventRegister.Visible = false;
                btnUnregister.Visible = true;
            }
        }
        private async Task CheckRegisterStatus()
        {
            var er = await _eventService.GetRegisteredEventById(_session.CurrentUser!.Id, eventDTO.Id);
            if (er == null)
            {
                ShowRegisterButton(true);
            }
            else
            {
                ShowRegisterButton(false);
            }
        }
        private async Task CheckEvidenceStatus()
        {
            var studentEvidence = await _evidenceService.GetByStudentEvent(eventDTO.Id, _session.CurrentUser!.Id);
            if (studentEvidence != null)
            {
                btnEvidence.Enabled = false;
                btnEvidence.Text = "Đã nộp minh chứng";
                this.btnEvidence.Refresh();
            }
        }
        private async void frmEventDetail_Load(object sender, EventArgs e)
        {
            if (_session.CurrentUser!.Student == null)
            {
                btnEventRegister.Visible = false;
                btnUnregister.Visible = false;
            }
            btnEvidence.Visible = false;
            await CheckRegisterStatus();
            FillData();
            if (eventDTO.Status == EventStatus.Completed)
            {
                btnEvidence.Visible = true;
                await CheckEvidenceStatus();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnEventRegister_Click(object sender, EventArgs e)
        {
            if (_session.CurrentUser!.Student == null)
            {
                Utils.ShowMessages("Lỗi", "Chỉ sinh viên mới được thực hiện thao tác này", this);
                return;
            }
            if (eventDTO.RegisteredAmount >= eventDTO.TargetedAmount)
            {
                Utils.ShowMessages("Thất bại", "Đã đủ số lượng người tham gia!", this);
                return;
            }
            var registerResult = await _eventService.RegisterEvent(eventDTO.Id, _session.CurrentUser.Id);
            if (registerResult == RegisterEventResult.IsRegistered)
            {
                Utils.ShowMessages("Thất bại", "Bạn đã đăng ký sự kiện này rồi", this);
                return;
            }
            Utils.ShowMessages("Thành công", "Bạn đã thành công đăng ký tham gia sự kiện\nCó thể hủy đăng ký trong vòng 30 phút", this);
            ShowRegisterButton(false);
        }

        private async void btnUnregister_Click(object sender, EventArgs e)
        {
            if (_session.CurrentUser!.Student == null)
            {
                Utils.ShowMessages("Lỗi", "Chỉ sinh viên mới được thực hiện thao tác này", this);
                return;
            }
            var unregisterResult = await _eventService.UnregisterEvent(eventDTO.Id, _session.CurrentUser.Id);
            if (unregisterResult == RegisterEventResult.OutOfTime)
            {
                Utils.ShowMessages("Thất bại", "Vượt quá thời gian, không thể hủy đăng ký", this);
                return;
            }
            Utils.ShowMessages("Thành công", "Hủy đăng ký sự kiện thành công", this);
            ShowRegisterButton(true);
        }

        private async void btnEvidence_Click(object sender, EventArgs e)
        {
            if (_session.CurrentUser!.Student == null)
            {
                Utils.ShowMessages("Lỗi", "Chỉ sinh viên mới được thực hiện thao tác này", this);
                return;
            }
            var evidenceForm = _serviceProvider.GetRequiredService<frmEvidence>();
            evidenceForm.eventId = eventDTO.Id;
            evidenceForm.ShowDialog();
            await CheckEvidenceStatus();
        }

        private void btnEvidenceList_Click(object sender, EventArgs e)
        {
            //if (_session.CurrentUser!.Organizer == null)
            //{
            //    Utils.ShowMessages("Lỗi", "Chỉ người tổ chức mới được thực hiện thao tác này", this);
            //    return;
            //}
            var evidenceListForm = _serviceProvider.GetRequiredService<frmEvidenceList>();
            evidenceListForm.eventDTO = eventDTO;
            evidenceListForm.ShowDialog();
        }
    }
}
