using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Presentation.Organizer.Dialogs;
using QLDRL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLDRL.Presentation.Manager.Appeals
{
    public partial class ucAppeals : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AppealService _appealService;
        public ucAppeals(Session session, IServiceProvider serviceProvider, AppealService appealService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _appealService = appealService;
        }
        private async Task LoadAppeals()
        {
            flpAppeals.Controls.Clear();
            var appeals = await _appealService.GetAll();
            foreach (var ap in appeals)
            {
                var appealItemControl = _serviceProvider.GetRequiredService<ucAppealItem>();
                appealItemControl.appeal = ap;
                flpAppeals.Controls.Add(appealItemControl);
            }
        }
        private async void ucAppeals_Load(object sender, EventArgs e)
        {
            await LoadAppeals();
        }
    }
}
