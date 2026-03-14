using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Presentation.Student.Dialogs;
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

namespace QLDRL.Presentation.Student
{
    public partial class ucPoints : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly PointCategoryService _pointCategoryService;
        private readonly Session _session;
        public ucPoints(IServiceProvider serviceProvider, PointCategoryService pointCategoryService, Session session)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _pointCategoryService = pointCategoryService;
            _session = session;
        }

        public async Task LoadPointReview()
        {
            var previews = await _pointCategoryService.GetStudentPreviewPoints(_session.CurrentUser.Id);
            foreach (var pd in previews)
            {
                var pointDTO = PointCategoryMapper.ToPointPreviewDTO(pd);
                var ucPreviewPoints = _serviceProvider.GetRequiredService<ucPreviewPoints>();
                ucPreviewPoints.pointDTO = pointDTO;
                flpPreviewPoints.Controls.Add(ucPreviewPoints);
            }
        }
        private async void ucPoints_Load(object sender, EventArgs e)
        {
            await LoadPointReview();
        }
    }
}
