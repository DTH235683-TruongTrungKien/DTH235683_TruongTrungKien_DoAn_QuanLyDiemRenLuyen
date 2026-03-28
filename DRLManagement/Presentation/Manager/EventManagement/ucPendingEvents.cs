using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Organizer.Dialogs;
using QLDRL.Services;

namespace QLDRL.Presentation.Manager.EventManagement
{
    public partial class ucPendingEvents : UserControl
    {
        private readonly EventService _eventService;
        private int? _selectedEventId = null;
        private Panel? _selectedPanel = null;
        private readonly IServiceProvider _serviceProvider;
        public ucPendingEvents(EventService eventService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _eventService = eventService;
            _serviceProvider = serviceProvider;
        }
        private void SelectEvent(Panel panel, int eventId)
        {
            if (_selectedPanel != null)
            {
                _selectedPanel.BackColor = Color.White;
            }
            _selectedPanel = panel;
            _selectedEventId = eventId;
            _selectedPanel.BackColor = Color.LightCyan;
        }
        public async Task LoadEvents(params EventStatus[] status)
        {
            flpEvents.Controls.Clear();
            _selectedEventId = null;
            _selectedPanel = null;

            var search = txtSearchBar.Text;
            var events = string.IsNullOrWhiteSpace(search)
                ? await _eventService.GetAllByStatus(status)
                : (await _eventService.SearchEvents(search)).Where(e => status.Contains(e.Status)).ToList();

            foreach (var ev in events)
            {
                var eventDTO = EventMapper.ToEventDTO(ev);

                var eventPreviewControl = _serviceProvider.GetRequiredService<ucEventPreview>();
                eventPreviewControl.EventDTO = eventDTO;
                var panel = eventPreviewControl.Controls["pnlEventPreview"] as Panel;
                panel.Click += (s, e) => SelectEvent(panel, eventDTO.Id);
                flpEvents.Controls.Add(eventPreviewControl);
            }
        }

        private async void ucPendingEvents_Load(object sender, EventArgs e)
        {
            await LoadEvents(EventStatus.Pending);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadEvents(EventStatus.Pending);
        }

        private async void btnPending_Click(object sender, EventArgs e)
        {
            await LoadEvents(EventStatus.Pending);
        }

        private async void btnVerified_Click(object sender, EventArgs e)
        {
            await LoadEvents(EventStatus.Upcoming, EventStatus.Ongoing, EventStatus.Completed);
        }

        private async void btnRejected_Click(object sender, EventArgs e)
        {
            await LoadEvents(EventStatus.Rejected);
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == null || _selectedPanel == null)
            {
                Utils.ShowMessages("Thông báo", "Vui lòng chọn một sự kiện", this.ParentForm!);
                return;
            }

            var confirm = Utils.ConfirmDialog(
                "Thông báo",
                "Bạn có chắc chắn muốn duyệt sự kiện này?\n(Không thể hoàn tác)",
                this.ParentForm!
            );

            if (confirm == DialogResult.Yes)
            {
                var validationResult = await _eventService.VerifyEvent(_selectedEventId.Value, true);
                if (validationResult == ValidateEventResult.VerifyFailed)
                {
                    Utils.ShowMessages("Thất bại", "Không thể duyệt sự kiện này", this.ParentForm!);
                    return;
                }
                await LoadEvents(EventStatus.Pending);
            }
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == null || _selectedPanel == null)
            {
                Utils.ShowMessages("Thông báo", "Vui lòng chọn một sự kiện", this.ParentForm!);
                return;
            }

            var confirm = Utils.ConfirmDialog(
                "Thông báo",
                "Bạn có chắc chắn muốn từ chối sự kiện này\n(Không thể hoàn tác)",
                this.ParentForm!
            );

            if (confirm == DialogResult.Yes)
            {
                var validationResult = await _eventService.VerifyEvent(_selectedEventId.Value, false);
                if (validationResult == ValidateEventResult.VerifyFailed)
                {
                    Utils.ShowMessages("Thất bại", "Không thể từ chối sự kiện này", this.ParentForm!);
                    return;
                }
                await LoadEvents(EventStatus.Pending);
            }
        }

        private void txtSearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
