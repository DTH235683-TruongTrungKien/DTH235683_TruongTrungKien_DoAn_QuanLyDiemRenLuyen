using QLDRL.DTOs.ManagerDTOs;
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
    public partial class ucManagerProfile : UserControl
    {
        public ManagerDTO _managerDTO;
        public ucManagerProfile(ManagerDTO managerDTO)
        {
            InitializeComponent();
            _managerDTO = managerDTO;
        }
        private void FillValue()
        {
            txtManagerCode.Text = _managerDTO.ManagerCode;
            txtManagerFaculty.Text = _managerDTO.FacultyName;
            txtDepartment.Text = _managerDTO.Department;
            txtManagerPosition.Text = _managerDTO.Position;
        }
        private void ucManagerProfile_Load(object sender, EventArgs e)
        {
            FillValue();
        }
    }
}
