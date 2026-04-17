using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Services;

namespace QLDRL.Presentation.Student.Confirms
{
    public partial class ucConfirms : UserControl
    {
        private readonly Session _session;
        private readonly ConfirmService _confirmService;
        private readonly IServiceProvider _serviceProvider;
        public ucConfirms(ConfirmService confirmService, Session session, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _confirmService = confirmService;
            _session = session;
            _serviceProvider = serviceProvider;
        }
        private async Task FillData()
        {
            if (_session.CurrentUser!.Student != null)
            {
                var confirms = await _confirmService.GetAllByStudent(_session.CurrentUser.Id);
                var confirmDTOs = ConfirmMapper.ToConfirmHistoryDTOList(confirms);
                dgvConfirms.DataSource = confirmDTOs;
            }
        }

        private async void ucConfirms_Load(object sender, EventArgs e)
        {
            await FillData();
        }

        private void btnConfirmRegister_Click(object sender, EventArgs e)
        {
            var registerConfirmForm = _serviceProvider.GetRequiredService<frmConfirmRegister>();
            registerConfirmForm.ShowDialog();
        }
    }
}
