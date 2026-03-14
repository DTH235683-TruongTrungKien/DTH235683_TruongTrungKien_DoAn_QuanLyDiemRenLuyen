using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.PointCategoryDTOs;

namespace QLDRL.Presentation.Student.Dialogs
{
    public partial class ucPreviewPoints : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        public PointPreviewDTO pointDTO;
        public ucPreviewPoints(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private void FillData()
        {
            lblSemesterName.Text = pointDTO.SemesterName;
            lblTotalScore.Text = pointDTO.TotalScore.ToString();
        }

        private void ucPreviewPoints_Load(object sender, EventArgs e)
        {
            if(pointDTO != null)
                FillData();
        }

        private void btnViewPoint_Click(object sender, EventArgs e)
        {
            var frmPointDetail = _serviceProvider.GetRequiredService<frmPointDetail>();
            frmPointDetail.SemesterId = pointDTO.SemesterId;
            frmPointDetail.ShowDialog();
        }
    }
}
