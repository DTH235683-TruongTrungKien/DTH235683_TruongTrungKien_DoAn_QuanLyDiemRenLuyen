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
    public partial class ucManagerPanel : UserControl
    {
        public event Action ucPointCategories_Load;
        public event Action ucPendingEvents_Load;
        public event Action ucAppeals_Load;
        public event Action ucConfirmManagement_Load;
        public ucManagerPanel()
        {
            InitializeComponent();
        }

        private void btnPointManage_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnPointManage);
            ucPointCategories_Load?.Invoke();
        }

        private void btnPendingEvent_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnPendingEvent);
            ucPendingEvents_Load?.Invoke();
        }
        private void btnAppeal_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnAppeal);
            ucAppeals_Load?.Invoke();
        }

        private void btnConfirmManagement_Click(object sender, EventArgs e)
        {
            MenuState.SetButtonState(btnConfirmManagement);
            ucConfirmManagement_Load?.Invoke();
        }
    }
}
