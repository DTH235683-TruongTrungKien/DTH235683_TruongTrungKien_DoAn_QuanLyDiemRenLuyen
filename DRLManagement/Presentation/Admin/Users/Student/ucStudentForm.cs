using QLDRL.DTOs.StudentDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Helpers.States;
using QLDRL.Services;

namespace QLDRL.Presentation.Admin.Dialogs
{
    public partial class ucStudentForm : UserControl
    {
        public AddUserRoleState State;
        private readonly int StudentRoleId = Convert.ToInt32(RoleType.Student);
        private readonly StudentService _studentService;
        private readonly StudentClassService _studentClassService;
        public ucStudentForm(StudentService studentService, StudentClassService studentClassService)
        {
            InitializeComponent();
            _studentService = studentService;
            _studentClassService = studentClassService;
        }
        private async void ucStudentForm_Load(object sender, EventArgs e)
        {
            if (State.StudentDTO != null)
                await FillStudentData(false);
        }
        private async Task FillStudentData(bool isBlank)
        {
            if(isBlank == true)
            {
                txtStudentCode.Text = "";
                txtStudentClass.Text = "";
                txtEnrollmentYear.Text = "";
                txtGraduationYear.Text = "";
                txtGPA.Text = "";
            }
            else
            {
                var studentClass = await _studentClassService.GetById(State.StudentDTO.StudentClassId);
                txtStudentCode.Text = State.StudentDTO.StudentCode;
                txtStudentClass.Text = studentClass.Name;
                txtEnrollmentYear.Text = State.StudentDTO.EnrollmentYear;
                txtGraduationYear.Text = State.StudentDTO.GraduationYear;
                txtGPA.Text = State.StudentDTO.GPA.ToString();
            }
        }

        private async void btnAddRole_Click(object sender, EventArgs e)
        {
            var studentClass = await _studentClassService.GetByClassName(txtStudentClass.Text);
            var studentDTO = new CreateUpdateStudentDTO
            {
                StudentCode = txtStudentCode.Text,
                StudentClassId = studentClass != null ? studentClass.Id : 0,
                EnrollmentYear = txtEnrollmentYear.Text,
                GraduationYear = txtGraduationYear.Text,
                GPA = !string.IsNullOrWhiteSpace(txtGPA.Text) ? Convert.ToDouble(txtGPA.Text) : 0.0
            };
            var validationResult = _studentService.ValidateStudent(studentDTO, studentClass);
            switch (validationResult)
            {
                case ValidateStudentResult.InvalidStudentCode:
                    Utils.ShowMessages("Lỗi", "Mã sinh viên không hợp lệ", this.ParentForm!);
                    break;

                case ValidateStudentResult.StudentClassNotFound:
                    Utils.ShowMessages("Lỗi", "Lớp không tồn tại", this.ParentForm!);
                    break;

                case ValidateStudentResult.InvalidEnrollmentYear:
                    Utils.ShowMessages("Lỗi", "Năm nhập học không hợp lệ", this.ParentForm!);
                    break;

                case ValidateStudentResult.InvalidGraduationYear:
                    Utils.ShowMessages("Lỗi", "Năm tốt nghiệp không hợp lệ", this.ParentForm!);
                    break;

                case ValidateStudentResult.InvalidGPA:
                    Utils.ShowMessages("Lỗi", "Điểm học tập không hợp lệ (0.0 - 10.0)", this.ParentForm!);
                    break;

                case ValidateStudentResult.Success:
                    if (!State.RoleIds.Contains(StudentRoleId))
                        State.RoleIds.Add(StudentRoleId);
                    State.StudentDTO = studentDTO;
                    Utils.ShowMessages("Thành công", "Cập nhật vai trò thành công", this.ParentForm!);
                    break;
            }
        }

        private async void btnRemoveRole_Click(object sender, EventArgs e)
        {
            if (!State.RoleIds.Contains(StudentRoleId))
            {
                Utils.ShowMessages("Lỗi thực thi", "Vai trò này chưa được thêm", this.ParentForm!);
                return;
            }
            State.RoleIds.Remove(StudentRoleId);
            State.StudentDTO = null;
            await FillStudentData(true);
            Utils.ShowMessages("Thành công", "Gỡ bỏ vai trò thành công", this.ParentForm!);
        }


    }
}
