using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Student.Points;
using QLDRL.Services;

namespace QLDRL.Presentation.Student.Events
{
    public partial class frmRegisteredEvents : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly EventService _eventService;
        private readonly Session _session;
        public frmRegisteredEvents(EventService eventService, Session session, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _eventService = eventService;
            _session = session;
            _serviceProvider = serviceProvider;
        }
        private async Task LoadRegisteredEvents()
        {
            var registeredEvents = await _eventService.GetAllStudentRegisteredEvents(_session.CurrentUser!.Id);
            var registeredEventsDTO = EventMapper.ToEventRegistrationDTOList(registeredEvents);

            foreach(var regisDTO in registeredEventsDTO)
            {
                var regisEventItemControl = _serviceProvider.GetRequiredService<ucRegisteredEventItem>();
                regisEventItemControl.regisDTO = regisDTO;
                flpRegisteredEvents.Controls.Add(regisEventItemControl);
            }
        }
        private async void frmRegisteredEvents_Load(object sender, EventArgs e)
        {
            if (_session.CurrentUser!.Student == null)
            {
                Utils.ShowMessages("Lỗi", "Chỉ sinh viên mới xem được danh sách này", this);
                return;
            }
            await LoadRegisteredEvents();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
