using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Models;
using QLDRL.Presentation.Shared;
using QLDRL.Services;

namespace QLDRL.Presentation.Organizer.EventManagement
{
    public partial class ucEvidenceItem : UserControl
    {
        public Evidence evidence;
        private readonly EventService _eventService;
        private readonly EvidenceService _evidenceService;
        private readonly PointCategoryService _pointCategoryService;
        public ucEvidenceItem(EventService eventService, PointCategoryService pointCategoryService, EvidenceService evidenceService)
        {
            InitializeComponent();
            _eventService = eventService;
            _pointCategoryService = pointCategoryService;
            _evidenceService = evidenceService;
        }
        private (string, Color) ConvertEvidenceStatus(EvidenceStatus status)
        {
            switch (status)
            {
                case EvidenceStatus.Processing:
                    return ("Đang xử lý", Color.Gold);
                case EvidenceStatus.Approved:
                    return ("Đã duyệt", Color.Green);
                case EvidenceStatus.Rejected:
                    return ("Bị từ chối", Color.Orange);
                default:
                    return (status.ToString(), Color.Black);
            }
        }
        private void FillData()
        {
            var (status, color) = ConvertEvidenceStatus(evidence.Status);
            lblStatus.Text = status;
            lblStatus.BackColor = color;
            lblStudent.Text = evidence.Student.User.FullName;
            lblTitle.Text = evidence.Title;
        }
        private void HideButton()
        {
            btnVerify.Visible = false;
            btnReject.Visible = false;
            btnVerify.Refresh();
            btnReject.Refresh();
        }
        private void ucEvidenceItem_Load(object sender, EventArgs e)
        {
            FillData();
            if (evidence.Status == EvidenceStatus.Approved || evidence.Status == EvidenceStatus.Rejected)
            {
                HideButton();
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            var evidenceImage = new frmImageDetail(evidence.ImagePath);
            evidenceImage.ShowDialog();
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            var result = Utils.ConfirmDialog("Xác nhận", "Bạn có chắc chắn muốn duyệt minh chứng này? (Không thể hoàn tác)", this.ParentForm!);
            if (result == DialogResult.Yes)
            {
                var eventRegis = await _eventService.GetRegisteredEventById(evidence.StudentUserId, evidence.EventId);
                if (eventRegis != null)
                {
                    await _evidenceService.SetStatus(evidence, EvidenceStatus.Approved);
                    await _eventService.SetRegisterStatus(eventRegis, AttendStatus.Attended);
                    await _pointCategoryService.ScoreCalculate(evidence.Event.SemesterId, evidence.StudentUserId, evidence.Event.PointCategoryId, evidence.Event.AddPoint);
                }
                HideButton();
            }
            
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            var result = Utils.ConfirmDialog("Xác nhận", "Bạn có chắc chắn muốn từ chối minh chứng này? (Không thể hoàn tác)", this.ParentForm!);
            if (result == DialogResult.Yes)
            {
                var eventRegis = await _eventService.GetRegisteredEventById(evidence.StudentUserId, evidence.EventId);
                if (eventRegis != null)
                {
                    await _evidenceService.SetStatus(evidence, EvidenceStatus.Rejected);
                    await _eventService.SetRegisterStatus(eventRegis, AttendStatus.NoAttended);
                    await _pointCategoryService.ScoreCalculate(evidence.Event.SemesterId, evidence.StudentUserId, evidence.Event.PointCategoryId, -evidence.Event.RemovePoint);
                }
                HideButton();
            }
        }
    }
}
