using QLDRL.Helpers.States;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Forms.Manager
{
    public partial class ucOrganizerPanel : UserControl
    {
        public event Action ucEventManagement;
        public ucOrganizerPanel()
        {
            InitializeComponent();
        }

        private void btnEventManage_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnEventManage);
            ucEventManagement?.Invoke();
        }
    }
}
