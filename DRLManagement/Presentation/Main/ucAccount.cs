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

namespace QLDRL.Presentation.Main
{
    public partial class ucAccount : UserControl
    {
        private UserService _userService;
        private Session _session;
        public ucAccount(UserService userService, Session session)
        {
            InitializeComponent();
            _userService = userService;
            _session = session;
        }

        private void accountInfoLoad()
        {
            txtEmail.Text = _session.CurrentUser.Email;
        }
        private void ucAccount_Load(object sender, EventArgs e)
        {
            accountInfoLoad();
        }
    }
}
