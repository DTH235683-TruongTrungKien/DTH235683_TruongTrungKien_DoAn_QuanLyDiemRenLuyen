using QLDRL.Helpers;
using QLDRL.Services;
using QLDRL.Models;
using QLDRL.Enums;

namespace QLDRL.Presentation.Student.Points
{
    public partial class frmAppeal : Form
    {
        public int eventId;
        private readonly Session _session;
        private readonly AppealService _appealService;
        public frmAppeal(AppealService appealService, Session session)
        {
            InitializeComponent();
            _appealService = appealService;
            _session = session;
        }
        private void frmAppeal_Load(object sender, EventArgs e)
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
            var appeal = new Models.Appeal()
            {
                Content = txtContent.Text,
                ImagePath = txtImagePath.Text,
                EventId = eventId,
                StudentUserId = _session.CurrentUser!.Id,
                Status = AppealStatus.Pending,
            };

            var validationResult = await _appealService.ValidateAppeal(appeal);
            switch (validationResult)
            {
                case ValidateAppealResult.EmptyContent:
                    Utils.ShowMessages("Thất bại", "Hãy nhập nội dung khiếu nại của bạn.", this);
                    break;
                case ValidateAppealResult.EmptyImagePath:
                    Utils.ShowMessages("Thất bại", "Hãy nộp ảnh minh chứng khiếu nại của bạn.", this);
                    break;
                case ValidateAppealResult.InvalidStudent:
                    Utils.ShowMessages("Lỗi", "Sinh viên không tồn tại", this);
                    break;
                case ValidateAppealResult.InvalidEvent:
                    Utils.ShowMessages("Lỗi", "Sự kiện không tồn tại", this);
                    break;
                case ValidateAppealResult.Success:
                    await _appealService.Create(appeal);
                    this.DialogResult = DialogResult.OK;
                    break;
                default:
                    Utils.ShowMessages("Lỗi", "Có lỗi hệ thống xảy ra", this);
                    break;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
