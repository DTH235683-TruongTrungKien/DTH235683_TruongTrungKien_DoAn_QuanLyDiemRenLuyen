using QLDRL.DTOs.AdminDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Presentation.Admin.Users.Admin
{
    public partial class ucAdminProfile : UserControl
    {
        public AdminDTO _adminDTO;
        public ucAdminProfile(AdminDTO adminDTO)
        {
            InitializeComponent();
            _adminDTO = adminDTO;
        }
        private void FillValue()
        {
            txtPermission.Text = _adminDTO.Permission;
            txtAdminDepartment.Text = _adminDTO.Department;
        }
        private void ucAdminProfile_Load(object sender, EventArgs e)
        {
            FillValue();
        }
    }
}
