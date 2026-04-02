using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.EventDTOs;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
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

namespace QLDRL.Presentation.Organizer.EventManagement
{
    public partial class frmEvidenceList : Form
    {
        private readonly EvidenceService _evidenceService;
        private readonly IServiceProvider _serviceProvider;
        public EventDTO eventDTO;
        public frmEvidenceList(EvidenceService evidenceService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _evidenceService = evidenceService;
            _serviceProvider = serviceProvider;
        }
        public async Task LoadEvidences()
        {
            var evidences = await _evidenceService.GetAllInEvent(eventDTO.Id);
            foreach (var evd in evidences)
            {
                var evidenceItemControl = _serviceProvider.GetRequiredService<ucEvidenceItem>();
                evidenceItemControl.evidence = evd;
                flpEvidences.Controls.Add(evidenceItemControl);
            }
        }
        private async void frmEvidenceList_Load(object sender, EventArgs e)
        {
            await LoadEvidences();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
