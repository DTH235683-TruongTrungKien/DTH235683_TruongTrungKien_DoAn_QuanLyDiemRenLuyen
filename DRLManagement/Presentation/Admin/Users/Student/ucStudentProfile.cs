using QLDRL.DTOs.StudentDTOs;
using QLDRL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDRL.Presentation.Admin.Dialogs.ViewProfile
{
    public partial class ucStudentProfile : UserControl
    {
        public StudentDTO _studentDTO;
        public ucStudentProfile(StudentDTO studentDTO)
        {
            InitializeComponent();
            _studentDTO = studentDTO;
        }
        private void FillValue()
        {
            txtStudentCode.Text = _studentDTO.StudentCode;
            txtStudentClass.Text = _studentDTO.ClassName;
            txtMajor.Text = _studentDTO.MajorName;
            txtFaculty.Text = _studentDTO.FacultyName;
            txtSchoolYear.Text = _studentDTO.SchoolYear;
            txtGPA.Text = _studentDTO.GPA.ToString();
        }
        private void studentProfile_Load(object sender, EventArgs e)
        {
            FillValue();
        }
    }
}
