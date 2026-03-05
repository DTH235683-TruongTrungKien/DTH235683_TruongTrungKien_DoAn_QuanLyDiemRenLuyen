using DRLManagement;
using Microsoft.Extensions.DependencyInjection;
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
        public frmLogin(AuthServices authServices, Session session)
        {
            InitializeComponent();
            _authServices = authServices;
            _session = session;

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
                _session.CurrentUser = user;
                var mainForm = Program.ServiceProvider.GetRequiredService<frmMain>();
                mainForm.FormClosed += (s, e) =>
                {
                    this.Show();
                    txtPassword.Clear();
                };
                mainForm.Show();
                this.Hide();
            }
            else
            {
                Utils.showMessages("Lỗi xác thực", "Email hoặc mật khẩu không chính xác.", this);
            }
        }
        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !btnShowHidePassword.Checked;
        }
    }
}
