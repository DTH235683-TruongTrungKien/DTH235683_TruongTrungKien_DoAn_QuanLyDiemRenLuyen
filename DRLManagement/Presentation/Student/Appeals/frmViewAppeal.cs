using QLDRL.Presentation.Shared;

namespace QLDRL.Presentation.Student.Appeal
{
    public partial class frmViewAppeal : Form
    {
        public Models.Appeal appeal;
        public frmViewAppeal()
        {
            InitializeComponent();
        }
        private void FillData()
        {
            txtEventName.Text = appeal.Event.Name;
            txtContent.Text = appeal.Content;
            txtImagePath.Text = appeal.ImagePath;
            txtManagerName.Text = appeal.Manager != null ? appeal.Manager.User.FullName : "";
            txtRespond.Text = appeal.Manager != null ? appeal.Response : "";
        }
        private void frmViewAppeal_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private void btnViewImage_Click(object sender, EventArgs e)
        {
            var imageDetailForm = new frmImageDetail(appeal.ImagePath);
            imageDetailForm.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
