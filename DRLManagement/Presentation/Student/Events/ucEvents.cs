using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Presentation.Organizer.Dialogs;
using QLDRL.Services;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Student.Events;

namespace QLDRL.Presentation.Student
{
    public partial class ucEvents : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly EventService _eventService;
        private readonly Session _session;
        private readonly StudentService _studentService;
        private int? _selectedEventId = null;
        private Panel? _selectedPanel = null;

        public ucEvents(IServiceProvider serviceProvider,
                        EventService eventService,
                        Session session,
                        StudentService studentService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _eventService = eventService;
            _session = session;
            _studentService = studentService;
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

            var student = await _studentService.GetById(_session.CurrentUser!.Id);
            if (student == null)
            {
                Utils.ShowMessages("Lỗi", "Danh sách này chỉ dành cho sinh viên", this.ParentForm!);
                return;
            }

            var events = string.IsNullOrWhiteSpace(search)
                ? await _eventService.GetAllForStudent(student.StudentClassId, student.StudentClass.Major.FacultyId)
                : (await _eventService.SearchEvents(search))
                    .Where(e => (!e.AllowClasses.Any() || e.AllowClasses.Any(c => c.Id == student.StudentClassId)) &&
                                (!e.AllowFaculties.Any() || e.AllowFaculties.Any(f => f.Id == student.StudentClass.Major.FacultyId)) &&
                                e.Status != EventStatus.Pending && e.Status != EventStatus.Rejected)
                    .ToList();

            foreach (var ev in events)
            {
                var eventDTO = EventMapper.ToEventDTO(ev);

                var eventPreviewControl = _serviceProvider.GetRequiredService<ucEventPreview>();
                eventPreviewControl.EventDTO = eventDTO;
                var panel = eventPreviewControl.Controls["pnlEventPreview"] as Panel;
                panel!.Click += (s, e) => SelectEvent(panel, eventDTO.Id);
                flpEvents.Controls.Add(eventPreviewControl);
            }
        }
        private async void ucEvents_Load(object sender, EventArgs e)
        {
            await LoadEvents();
        }

        private void btnRegisteredEvents_Click(object sender, EventArgs e)
        {
            var reControl = _serviceProvider.GetRequiredService<frmRegisteredEvents>();
            reControl.ShowDialog();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadEvents(txtSearchBar.Text);
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
