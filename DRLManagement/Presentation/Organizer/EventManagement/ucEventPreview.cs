using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.EventDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Services;

namespace QLDRL.Presentation.Organizer.Dialogs
{
    public partial class ucEventPreview : UserControl
    {
        public EventDTO EventDTO;
        private readonly EventService _eventService;
        public IServiceProvider _serviceProvider;
        private readonly EvidenceService _evidenceService;
        public ucEventPreview(IServiceProvider serviceProvider, EvidenceService evidenceService, EventService eventService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _evidenceService = evidenceService;
            _eventService = eventService;
        }
        private (string, Color) ConvertEventStatus(EventStatus status)
        {
            switch (status)
            {
                case EventStatus.Pending:
                    return ("Đang chờ duyệt", Color.Gold);
                case EventStatus.Upcoming:
                    return ("Sắp diễn ra", Color.Green);
                case EventStatus.Ongoing:
                    return ("Đang diễn ra", Color.Orange);
                case EventStatus.Completed:
                    return ("Đã hoàn thành", Color.DodgerBlue);
                case EventStatus.HaveEvidence:
                    return ("Đã hoàn thành - Chờ duyệt", Color.Purple);
                case EventStatus.Rejected:
                            return ("Bị từ chối", Color.Red);
                default:
                            return (status.ToString(), Color.Black);
                        }
        }
        public void FillValue()
        {
            pbEventThumbnail.Image = Image.FromFile(Utils.FillImage(EventDTO.ImagePath));
            var (status, color) = ConvertEventStatus(EventDTO.Status);
            lblStatus.Text = status;
            lblStatus.BackColor = color;
            lblEventName.Text = EventDTO.Name;
            lblOrganizationUnit.Text = EventDTO.OrganizationUnit;
            lblStartDate.Text = EventDTO.StartDate.ToString();
            lblEndDate.Text = EventDTO.EndDate.ToString();
        }

        private async void ucEventPreview_Load(object sender, EventArgs e)
        {
            FillValue();
        }

        private void pnlEventPreview_DoubleClick(object sender, EventArgs e)
        {
            var eventDetailForm = _serviceProvider.GetRequiredService<frmEventDetail>();
            eventDetailForm.eventDTO = EventDTO;
            eventDetailForm.ShowDialog();
        }
    }
}
