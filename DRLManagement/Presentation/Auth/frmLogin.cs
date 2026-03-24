using DRLManagement;
using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.Forms.Main;
using QLDRL.Helpers;
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

namespace QLDRL.Forms.Auth
{
    public partial class frmLogin : Form
    {
        private readonly AuthServices _authServices;
        private readonly Session _session;
        private readonly IServiceProvider _serviceProvider;
        public frmLogin(AuthServices authServices, Session session, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _authServices = authServices;
            _session = session;
            _serviceProvider = serviceProvider;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            gbLogin.Text = "Đang đăng nhập...";
            gbLogin.Refresh();
            gbLogin.Text = "Đăng nhập";
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            
            var user = await _authServices.Login(email, password);
            if (user != null)
            {
                _session.SetCurrentUser(user);
                var frmMain = _serviceProvider.GetRequiredService<frmMain>();

                frmMain.FormClosed += (s, e) =>
                {
                    this.Show();
                    txtPassword.Clear();
                };

                frmMain.Show();
                this.Hide();
            }
            else
            {
                Utils.ShowMessages("Lỗi xác thực", "Email hoặc mật khẩu không chính xác.", this);
            }
        }
        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !btnShowHidePassword.Checked;
        }
    }
}
