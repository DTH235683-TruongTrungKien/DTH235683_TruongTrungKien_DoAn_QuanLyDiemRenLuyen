using QLDRL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Forms.Admin
{
    public partial class ucAdminPanel : UserControl
    {
        public ucAdminPanel()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnUser);
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnControl);
        }
    }
}
