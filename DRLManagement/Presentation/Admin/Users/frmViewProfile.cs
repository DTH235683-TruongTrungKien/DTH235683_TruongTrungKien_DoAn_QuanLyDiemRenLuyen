using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Presentation.Admin.Dialogs.ViewProfile;
using QLDRL.Presentation.Admin.Users.Admin;
using QLDRL.Presentation.Admin.Users.Organizer;
using QLDRL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace QLDRL.Presentation.Admin.Dialogs
{
    public partial class frmViewProfile : Form
    {
        public UserDTO userDTO;
        private readonly UserServices _userServices;
        public frmViewProfile(UserServices userServices)
        {
            InitializeComponent();
            _userServices = userServices;
        }
        public void FillProfile()
        {
            txtEmail.Text = userDTO.Email;
            txtStatus.Text = userDTO.Status;
            txtFullName.Text = userDTO.FullName;
            txtBirthday.Text = userDTO.Birthday;
            txtPhoneNumber.Text = userDTO.PhoneNumber;
            txtAddress.Text = userDTO.Address;
        }
        private async Task cboRoles_Load()
        {
            var roles = await _userServices.GetRolesByUserId(userDTO.Id);
            cboRoles.DisplayMember = "Name";
            cboRoles.ValueMember = "Id";
            cboRoles.DataSource = roles;
            cboRoles.SelectedIndex = 0;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmViewProfile_Load(object sender, EventArgs e)
        {
            FillProfile();
            await cboRoles_Load();
        }

        private async void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var user = await _userServices.GetById(userDTO.Id);
            var roleId = (RoleType)Convert.ToInt32(cboRoles.SelectedValue);
            if (roleId == RoleType.Admin)
            {
                var adminDTO = AdminMapper.ToAdminDTO(user.Admin);
                var adminProfile = new ucAdminProfile(adminDTO);
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(adminProfile);
            }
            if (roleId == RoleType.Manager)
            {
                var managerDTO = ManagerMapper.ToManagerDTO(user.Manager);
                var managerProfile = new ucManagerProfile(managerDTO);
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(managerProfile);
            }
            if (roleId == RoleType.Organizer)
            {
                var organizerDTO = OrganizerMapper.ToOrganizerDTO(user.Organizer);
                var organizerProfile = new ucOrganizerProfile(organizerDTO);
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(organizerProfile);
            }
            if (roleId == RoleType.Student)
            {
                var studentDTO = StudentMapper.ToStudentDTO(user.Student);
                var studentProfile = new ucStudentProfile(studentDTO);
                pnlProfile.Controls.Clear();
                pnlProfile.Controls.Add(studentProfile);
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
