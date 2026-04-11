using QLDRL.DTOs.AppealDTOs;
using QLDRL.Enums;
using QLDRL.Presentation.Shared;
using QLDRL.Services;

namespace QLDRL.Presentation.Manager.Appeals
{
    public partial class frmAppealDetail : Form
    {
        public Models.Appeal appeal;
        private readonly AppealService _appealService;
        private readonly EventService _eventService;
        private readonly PointCategoryService _pointCategoryService;
        private readonly Session _session;
        public frmAppealDetail(Session session, AppealService appealService, EventService eventService, PointCategoryService pointCategoryService)
        {
            InitializeComponent();
            _session = session;
            _appealService = appealService;
            _eventService = eventService;
            _pointCategoryService = pointCategoryService;
        }
        private void FillData()
        {
            txtEventName.Text = appeal.Event.Name;
            txtContent.Text = appeal.Content;
            txtImagePath.Text = appeal.ImagePath;
            txtManagerName.Text = appeal.Manager != null ? appeal.Manager.User.FullName : _session.CurrentUser!.FullName;
            txtRespond.Text = appeal.Manager != null ? appeal.Response : "";
        }
        private void CheckAppealStatus()
        {
            if (appeal.Status != AppealStatus.Pending)
            {
                btnVerify.Enabled = false;
                btnReject.Enabled = false;
            }
            btnVerify.Refresh();
            btnReject.Refresh();
        }
        private void frmAppealDetail_Load(object sender, EventArgs e)
        {
            //if(_session.CurrentUser.)
            CheckAppealStatus();
            FillData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImageView_Click(object sender, EventArgs e)
        {
            var imageDetailForm = new frmImageDetail(appeal.ImagePath);
            imageDetailForm.ShowDialog();
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            var eventRegis =  await _eventService.GetRegisteredEventById(appeal.StudentUserId, appeal.EventId);
            if (eventRegis != null)
            {
                var updateDTO = new UpdateAppealDTO()
                {
                    ManagerUserId = _session.CurrentUser!.Id,
                    Status = AppealStatus.Approved,
                    Response = txtRespond.Text,
                };
                await _appealService.Update(appeal, updateDTO);

                await _appealService.SetStatus(appeal, AppealStatus.Approved);
                await _eventService.SetRegisterStatus(eventRegis, AttendStatus.Attended);
                await _pointCategoryService.ScoreCalculate(appeal.Event.SemesterId, appeal.StudentUserId, appeal.Event.PointCategoryId, appeal.Event.RemovePoint);
                await _pointCategoryService.ScoreCalculate(appeal.Event.SemesterId, appeal.StudentUserId, appeal.Event.PointCategoryId, appeal.Event.AddPoint);
            }
            this.Close();
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            var updateDTO = new UpdateAppealDTO()
            {
                ManagerUserId = _session.CurrentUser!.Id,
                Status = AppealStatus.Approved,
                Response = txtRespond.Text,
            };
            await _appealService.SetStatus(appeal, AppealStatus.Rejected);
            await _appealService.Update(appeal, updateDTO);
            this.Close();
        }
    }
}
