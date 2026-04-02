using QLDRL.Helpers;
using QLDRL.Services;
using QLDRL.Models;
using QLDRL.Enums;

namespace QLDRL.Presentation.Student.Events
{
    public partial class frmEvidence : Form
    {
        public int eventId;
        private readonly Session _session;
        private readonly EvidenceService _evidenceService;
        public frmEvidence(EvidenceService evidenceService, Session session)
        {
            InitializeComponent();
            _evidenceService = evidenceService;
            _session = session;
        }

        private void frmEvidence_Load(object sender, EventArgs e)
        {
            if (_session.CurrentUser == null || eventId == 0)
                this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string? fullPath = Utils.UploadImage();
            if (!string.IsNullOrEmpty(fullPath))
            {
                txtImagePath.Text = Path.GetRelativePath(Application.StartupPath, fullPath);
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var evd = new Evidence()
            {
                Title = txtTitle.Text,
                ImagePath = txtImagePath.Text,
                EventId = eventId,
                StudentUserId = _session.CurrentUser!.Id,
                Status = EvidenceStatus.Processing,
            };
            var validationResult = await _evidenceService.ValidateEvidence(evd);
            switch(validationResult)
            {
                case ValidateEvidenceResult.EmptyImagePath:
                    Utils.ShowMessages("Thất bại", "Hãy nộp ảnh minh chứng tham gia sự kiện của bạn.", this);
                    break;
                case ValidateEvidenceResult.InvalidStudent:
                    Utils.ShowMessages("Lỗi", "Sinh viên không tồn tại", this);
                    break;
                case ValidateEvidenceResult.InvalidEvent:
                    Utils.ShowMessages("Lỗi", "Sự kiện không tồn tại", this);
                    break;
                case ValidateEvidenceResult.Success:
                    await _evidenceService.Create(evd);
                    break;
                default:
                    Utils.ShowMessages("Lỗi", "Có lỗi hệ thống xảy ra", this);
                    break;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
