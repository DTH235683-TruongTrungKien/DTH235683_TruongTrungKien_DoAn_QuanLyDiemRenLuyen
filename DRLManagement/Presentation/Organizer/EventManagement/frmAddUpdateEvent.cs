using QLDRL.DTOs.EventDTOs;
using QLDRL.Enums;
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

namespace QLDRL.Presentation.Organizer.EventManagement
{
    public partial class frmAddUpdateEvent : Form
    {
        private List<int> _selectedFacultyIds = new();
        private List<int> _selectedClassIds = new();

        private readonly Session _session;
        private readonly EventService _eventService;
        private readonly SemesterService _semesterService;
        private readonly PointCategoryService _pointCategoryService;
        private readonly StudentClassService _studentClassService;

        public FormMode Mode;
        public CreateUpdateEventDTO? eventDTO;

        private string _imagePath = "Images/no-image.png";

        public frmAddUpdateEvent(
            Session session,
            EventService eventService,
            SemesterService semesterService,
            PointCategoryService pointCategoryService,
            StudentClassService studentClassService)
        {
            InitializeComponent();

            _eventService = eventService;
            _semesterService = semesterService;
            _pointCategoryService = pointCategoryService;
            _studentClassService = studentClassService;
            _session = session;
        }
        private async Task LoadSemesters()
        {
            var semesters = await _semesterService.GetAll();
            cboSemester.DisplayMember = "Name";
            cboSemester.ValueMember = "Id";
            cboSemester.DataSource = semesters;
        }

        private async Task LoadPointCategories()
        {
            var categories = await _pointCategoryService.GetAll();
            cboPointCategory.DisplayMember = "Category";
            cboPointCategory.ValueMember = "Id";
            cboPointCategory.DataSource = categories;
        }
        private async Task LoadFaculties()
        {
            var faculties = await _studentClassService.GetAllFaculties();

            cboFaculty.DisplayMember = "Name";
            cboFaculty.ValueMember = "Id";
            cboFaculty.DataSource = faculties;
        }

        private async Task LoadClasses()
        {
            var classes = await _studentClassService.GetAll();

            cboStudentClass.DisplayMember = "Name";
            cboStudentClass.ValueMember = "Id";
            cboStudentClass.DataSource = classes;
        }
        private async Task LoadAllowData()
        {
            var ev = await _eventService.GetById(eventDTO.Id.Value);

            _selectedFacultyIds = ev.AllowFaculties.Select(f => f.Id).ToList();
            _selectedClassIds = ev.AllowClasses.Select(c => c.Id).ToList();

            RenderFaculties();
            RenderClasses();
        }
        private void FillData()
        {
            txtTitle.Text = eventDTO.Name;
            txtDescription.Text = eventDTO.Description;

            pbEventImage.Image = Image.FromFile(Utils.FillImage(eventDTO.ImagePath));
            _imagePath = eventDTO.ImagePath;

            txtOrganizationUnit.Text = eventDTO.OrganizationUnit;
            txtLocation.Text = eventDTO.Location;

            dtpStartDate.Value = eventDTO.StartDate;
            dtpEndDate.Value = eventDTO.EndDate;
            dtpRegistrationEnd.Value = eventDTO.RegistrationExpired;

            cboSemester.SelectedValue = eventDTO.SemesterId;
            cboPointCategory.SelectedValue = eventDTO.PointCategoryId;

            txtAddPoint.Text = eventDTO.AddPoint.ToString();
            txtRemovePoint.Text = eventDTO.RemovePoint.ToString();

            txtTargetedAmount.Text = eventDTO.TargetedAmount.ToString();
        }
        private async void frmAddUpdateEvent_Load(object sender, EventArgs e)
        {
            await LoadSemesters();
            await LoadPointCategories();
            await LoadFaculties();
            await LoadClasses();

            if (Mode == FormMode.Create)
            {
                this.Text = "THÊM SỰ KIỆN";
            }
            else
            {
                Utils.PrintDebug(eventDTO);
                this.Text = "CẬP NHẬT SỰ KIỆN";
                await LoadAllowData();
                FillData();
            }
        }

        private CreateUpdateEventDTO GetDTO()
        {
            return new CreateUpdateEventDTO
            {
                Id = eventDTO?.Id,
                Name = txtTitle.Text,
                Description = txtDescription.Text,
                ImagePath = _imagePath,
                OrganizationUnit = txtOrganizationUnit.Text,
                Location = txtLocation.Text,

                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                RegistrationExpired = dtpRegistrationEnd.Value,

                SemesterId = Convert.ToInt32(cboSemester.SelectedValue),
                PointCategoryId = Convert.ToInt32(cboPointCategory.SelectedValue),
                OrganizerUserId = _session.CurrentUser!.Id,
                AddPoint = int.TryParse(txtAddPoint.Text, out var add) ? add : -1,
                RemovePoint = int.TryParse(txtRemovePoint.Text, out var remove) ? remove : -1,
                TargetedAmount = int.TryParse(txtTargetedAmount.Text, out var amount) ? amount : -1,
                AllowFacultyIds = _selectedFacultyIds,
                AllowClassIds = _selectedClassIds
            };
        }
        private async Task<(int, ValidateEventResult)> CreateEvent()
        {
            var dto = GetDTO();
            Utils.PrintDebug(dto);
            var validation = await _eventService.Validate(dto);

            int id = 0;
            if (validation == ValidateEventResult.Success)
                id = await _eventService.Create(dto);
            return (id, validation);
        }

        private async Task<ValidateEventResult> UpdateEvent()
        {
            var dto = GetDTO();
            var validation = await _eventService.Validate(dto);

            if (validation == ValidateEventResult.Success)
                await _eventService.Update(dto.Id.Value, dto);

            return validation;
        }

        private void RenderFaculties()
        {
            var faculties = cboFaculty.DataSource as List<Faculty>;

            var names = faculties
                .Where(f => _selectedFacultyIds.Contains(f.Id))
                .Select(f => f.Name);

            txtAllowFaculties.Text = string.Join(", ", names);
        }

        private void RenderClasses()
        {
            var classes = cboStudentClass.DataSource as List<StudentClass>;

            var names = classes
                .Where(c => _selectedClassIds.Contains(c.Id))
                .Select(c => c.Name);

            txtAllowClasses.Text = string.Join(", ", names);
        }
        private void btnAddFaculty_Click(object sender, EventArgs e)
        {
            var facultyId = Convert.ToInt32(cboFaculty.SelectedValue);

            if (_selectedFacultyIds.Contains(facultyId))
                return;

            _selectedFacultyIds.Add(facultyId);
            RenderFaculties();
        }
        private void btnRemoveFaculty_Click(object sender, EventArgs e)
        {
            var facultyId = Convert.ToInt32(cboFaculty.SelectedValue);

            _selectedFacultyIds.Remove(facultyId);
            RenderFaculties();
        }
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var classId = Convert.ToInt32(cboStudentClass.SelectedValue);

            if (_selectedClassIds.Contains(classId))
                return;

            _selectedClassIds.Add(classId);
            RenderClasses();
        }
        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            var classId = Convert.ToInt32(cboStudentClass.SelectedValue);

            _selectedClassIds.Remove(classId);
            RenderClasses();
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            ValidateEventResult result;
            int id = 0;

            if (Mode == FormMode.Create)
            {
                (id, result) = await CreateEvent();
            }
            else
            {
                result = await UpdateEvent();
            }

            switch (result)
            {
                case ValidateEventResult.EmptyName:
                    Utils.ShowMessages("Lỗi", "Tên sự kiện không được để trống", this);
                    txtTitle.Focus();
                    break;

                case ValidateEventResult.EmptyOrganizationUnit:
                    Utils.ShowMessages("Lỗi", "Đơn vị tổ chức không được để trống", this);
                    txtOrganizationUnit.Focus();
                    break;

                case ValidateEventResult.InvalidSemester:
                    Utils.ShowMessages("Lỗi", "Học kỳ không hợp lệ", this);
                    cboSemester.Focus();
                    break;

                case ValidateEventResult.InvalidRegistrationExpired:
                    Utils.ShowMessages("Lỗi", "Hạn đăng ký không hợp lệ", this);
                    dtpRegistrationEnd.Focus();
                    break;

                case ValidateEventResult.InvalidStartDate:
                    Utils.ShowMessages("Lỗi", "Ngày bắt đầu phải sau hạn đăng ký", this);
                    dtpStartDate.Focus();
                    break;

                case ValidateEventResult.InvalidEndDate:
                    Utils.ShowMessages("Lỗi", "Ngày kết thúc phải sau ngày bắt đầu", this);
                    dtpEndDate.Focus();
                    break;

                case ValidateEventResult.InvalidPoint:
                    Utils.ShowMessages("Lỗi", "Điểm không hợp lệ", this);
                    txtAddPoint.Focus();
                    break;

                case ValidateEventResult.InvalidAmount:
                    Utils.ShowMessages("Lỗi", "Số lượng không hợp lệ", this);
                    txtAddPoint.Focus();
                    break;

                case ValidateEventResult.Success:
                    Utils.ShowMessages("Thành công", Mode == FormMode.Create ? "Tạo sự kiện thành công" : "Cập nhật thành công", this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;

                default:
                    Utils.ShowMessages("Lỗi", "Có lỗi xảy ra", this);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pbEventImage_Click(object sender, EventArgs e)
        {
            string? fullPath = Utils.UploadImage();

            if (!string.IsNullOrEmpty(fullPath))
            {
                _imagePath = Path.GetRelativePath(Application.StartupPath, fullPath);

                pbEventImage.Image = Image.FromFile(fullPath);
            }
        }
    }
}
