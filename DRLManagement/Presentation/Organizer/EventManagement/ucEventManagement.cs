using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Presentation.Organizer.Dialogs;
using QLDRL.Services;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Organizer.EventManagement;

namespace QLDRL.Presentation.Organizer
{
    public partial class ucEventManagement : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly EventService _eventService;
        private readonly Session _session;
        private int? _selectedEventId = null;
        private Panel? _selectedPanel = null;

        public ucEventManagement(IServiceProvider serviceProvider,
                        EventService eventService,
                        Session session)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _eventService = eventService;
            _session = session;

            btnSearch.Click += btnSearch_Click;
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
        public async Task LoadEvents(string search = "")
        {
            flpEvents.Controls.Clear();
            _selectedEventId = null;
            _selectedPanel = null;

            var events = string.IsNullOrWhiteSpace(search)
                ? await _eventService.GetAllByOrganizerId(_session.CurrentUser.Id)
                : (await _eventService.SearchEvents(search)).Where(e => e.OrganizerUserId == _session.CurrentUser.Id).ToList();

            foreach (var ev in events)
            {
                var eventDTO = EventMapper.ToEventDTO(ev);

                var eventPreviewControl = _serviceProvider.GetRequiredService<ucEventPreview>();
                eventPreviewControl.EventDTO = eventDTO;
                var panel = eventPreviewControl.Controls["pnlEventPreview"] as Panel;
                panel.Click += (s, e) => SelectEvent(panel, eventDTO.Id);

                foreach (Control c in panel.Controls)
                {
                    c.Click += (s, e) => SelectEvent(panel, ev.Id);
                }
                flpEvents.Controls.Add(eventPreviewControl);
            }
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadEvents(txtSearchBar.Text);
        }

        private async void ucEvents_Load(object sender, EventArgs e)
        {
            await LoadEvents();
        }

        private async void btnAddEvent_Click(object sender, EventArgs e)
        {
            var popup = _serviceProvider.GetRequiredService<frmAddUpdateEvent>();
            popup.Mode = FormMode.Create;

            var result = popup.ShowDialog();
            if (result == DialogResult.OK)
                await LoadEvents();
        }

        private async void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == null)
            {
                Utils.ShowMessages("Thông báo", "Vui lòng chọn sự kiện", this.ParentForm!);
                return;
            }

            var ev = await _eventService.GetById(_selectedEventId.Value);
            var dto = EventMapper.ToCreateUpdateEventDTO(ev);

            var popup = _serviceProvider.GetRequiredService<frmAddUpdateEvent>();
            popup.Mode = FormMode.Update;
            popup.eventDTO = dto;

            var result = popup.ShowDialog();
            if (result == DialogResult.OK)
                await LoadEvents();
        }

        private async void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (_selectedEventId == null)
            {
                Utils.ShowMessages("Thông báo", "Vui lòng chọn sự kiện", this.ParentForm!);
                return;
            }

            var confirm = Utils.ConfirmDialog(
                "Xóa sự kiện",
                "Bạn có chắc chắn muốn xóa sự kiện này?",
                this.ParentForm!
            );

            if (confirm == DialogResult.Yes)
            {
                await _eventService.Delete(_selectedEventId.Value);
                Utils.ShowMessages("Thông báo", "Xóa thành công", this.ParentForm!);

                await LoadEvents();
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
