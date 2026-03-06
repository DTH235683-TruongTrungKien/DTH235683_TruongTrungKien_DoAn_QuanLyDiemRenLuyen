using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.DTOs.StudentDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Presentation.Admin.Users.Organizer
{
    public partial class ucOrganizerProfile : UserControl
    {
        public OrganizerDTO _organizerDTO;
        public ucOrganizerProfile(OrganizerDTO organizerDTO)
        {
            InitializeComponent();
            _organizerDTO = organizerDTO;
        }
        private void FillValue()
        {
            txtClubName.Text = _organizerDTO.ClubName;
            txtPosition.Text = _organizerDTO.Position;
        }
        private void ucOrganizerProfile_Load(object sender, EventArgs e)
        {
            FillValue();
        }
    }
}
