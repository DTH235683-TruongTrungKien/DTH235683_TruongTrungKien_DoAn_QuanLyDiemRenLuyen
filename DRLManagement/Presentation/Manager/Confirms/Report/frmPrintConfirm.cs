using Microsoft.Reporting.WinForms;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Helpers;
using QLDRL.Models;
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

namespace QLDRL.Presentation.Manager.Confirms
{
    public partial class frmPrintConfirm : Form
    {
        private ReportViewer rptConfirm;
        public Confirm confirm;
        private readonly PointCategoryService _pointCategoryService;
        private readonly SemesterService _semsterService;
        public frmPrintConfirm(PointCategoryService pointCategoryService, SemesterService semesterService)
        {
            InitializeComponent();

            rptConfirm = new ReportViewer();
            rptConfirm.Dock = DockStyle.Fill;
            this.Controls.Add(rptConfirm);

            _pointCategoryService = pointCategoryService;
            _semsterService = semesterService;
        }

        private async void ShowReport()
        {
            string reportPath = Path.Combine(Application.StartupPath, "Presentation", "Manager", "Confirms", "Report", "rptConfirm.rdlc");
            rptConfirm.LocalReport.ReportPath = reportPath;

            rptConfirm.SetDisplayMode(DisplayMode.PrintLayout);

            var studentReport = PointCategoryMapper.ToStudentReportDTO(confirm.Student);
            var semester = await _semsterService.GetById(confirm.SemesterId);
            var rawListPoints = await _pointCategoryService.GetStudentPointDetails(confirm.SemesterId, confirm.StudentUserId);
            var listPoints = rawListPoints.Where(lp => lp.PointCategory.Category != "Total").ToList();
            var listPointsDTO = PointCategoryMapper.ToTrainingPointReportDTOList(listPoints);
            Utils.PrintDebug(listPoints);
            Utils.PrintDebug(listPointsDTO);
            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("pSemesterName", semester!.Name),
                new ReportParameter("pStudentName", studentReport.FullName),
                new ReportParameter("pStudentCode", studentReport.StudentCode),
                new ReportParameter("pStudentClass", studentReport.StudentClass),
                new ReportParameter("pStudentFaculty", studentReport.StudentFaculty)
            };
            rptConfirm.LocalReport.SetParameters(reportParameters);

            rptConfirm.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("TrainingPoint", listPointsDTO);
            rptConfirm.LocalReport.DataSources.Add(rds);

            rptConfirm.RefreshReport();
        }
        private void frmPrintConfirm_Load(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}
