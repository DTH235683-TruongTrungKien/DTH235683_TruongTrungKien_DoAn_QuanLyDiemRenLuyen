using Microsoft.Extensions.DependencyInjection;
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

namespace QLDRL.Presentation.Manager.Confirms
{
    public partial class ucConfirmManagement : UserControl
    {
        private readonly ConfirmService _confirmService;
        private readonly IServiceProvider _serviceProvider;
        public ucConfirmManagement(ConfirmService confirmService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _confirmService = confirmService;
            _serviceProvider = serviceProvider;
        }
        private async Task LoadConfirms()
        {
            var confirms = await _confirmService.GetAll();
            flpConfirms.Controls.Clear();
            foreach(var confirm in confirms)
            {
                var confirmItemControl = _serviceProvider.GetRequiredService<ucConfirmItem>();
                confirmItemControl.confirm = confirm;
                flpConfirms.Controls.Add(confirmItemControl);
            }
        }
        private async void ucConfirms_Load(object sender, EventArgs e)
        {
            await LoadConfirms();
        }
    }
}
