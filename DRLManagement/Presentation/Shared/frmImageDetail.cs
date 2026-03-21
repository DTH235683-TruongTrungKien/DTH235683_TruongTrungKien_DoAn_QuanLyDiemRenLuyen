using QLDRL.Helpers;

namespace QLDRL.Presentation.Shared
{
    public partial class frmImageDetail : Form
    {
        private readonly string _imagePath;
        public frmImageDetail(string imagePath)
        {
            InitializeComponent();
            _imagePath = imagePath;
        }

        private void frmImageDetail_Load(object sender, EventArgs e)
        {
            Utils.PrintDebug(_imagePath);
            using (var img = Image.FromFile(Utils.FillImage(_imagePath)))
            {
                pbImage.Image = new Bitmap(img);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
