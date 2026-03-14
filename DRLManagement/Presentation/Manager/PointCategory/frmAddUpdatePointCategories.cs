using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Services;
using QLDRL.Helpers;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;

namespace QLDRL.Presentation.Manager.PointCategory
{
    public partial class frmAddUpdatePointCategories : Form
    {
        private readonly PointCategoryService _pointCategoryService;

        public FormMode Mode { get; set; } = FormMode.Create;
        public PointCategoryDTO? PointCategoryDTO { get; set; }

        private List<PointCategoryDTO> _allCategories = new();

        public frmAddUpdatePointCategories(PointCategoryService pointCategoryService)
        {
            InitializeComponent();
            _pointCategoryService = pointCategoryService;
        }

        private async void frmAddUpdatePointCategories_Load(object sender, EventArgs e)
        {
            await LoadParentCategories();

            if (Mode == FormMode.Update)
            {
                FillPointCategoryData();
                lblFormTitle.Text = "CHỈNH SỬA MỤC ĐIỂM";
            }
        }

        private async Task LoadParentCategories()
        {
            var roots = await _pointCategoryService.GetAll();
            _allCategories = PointCategoryMapper.ToPointCategoryDTOList(roots);

            cboParentCategory.DisplayMember = "Category";
            cboParentCategory.ValueMember = "Id";

            var list = new List<PointCategoryDTO>();
            list.Add(new PointCategoryDTO { Id = 0, Category = "(Không có)" });
            list.AddRange(_allCategories);

            cboParentCategory.DataSource = list;
            cboParentCategory.SelectedIndex = 0;
        }

        private void FillPointCategoryData()
        {
            txtCategory.Text = PointCategoryDTO.Category;
            txtPointTitle.Text = PointCategoryDTO.Title;
            txtMaxScore.Text = PointCategoryDTO.MaxScore.ToString();

            if (PointCategoryDTO.ParentId.HasValue)
                cboParentCategory.SelectedValue = PointCategoryDTO.ParentId.Value;
            else
                cboParentCategory.SelectedIndex = 0;
        }

        private async Task<ValidatePointCategoryResult> CreateUpdatePointCategory()
        {
            int? parentId = null;
            var selectedNode = cboParentCategory.SelectedValue;
            if (selectedNode != null)
            {
                parentId = Convert.ToInt32(selectedNode);
            }
                
            var dto = new CreateUpdatePointCategoryDTO
            {
                Category = txtCategory.Text,
                Title = txtPointTitle.Text,
                MaxScore = int.TryParse(txtMaxScore.Text, out var maxScore) ? maxScore : -1,
                ParentId = parentId
            };

            ValidatePointCategoryResult result;
            if (Mode == FormMode.Create)
            {
                result = await _pointCategoryService.Validate(dto);
                if (result == ValidatePointCategoryResult.Success)
                    await _pointCategoryService.Create(dto);
            }
            else
            {
                result = await _pointCategoryService.Validate(dto, PointCategoryDTO.Id);
                if (result == ValidatePointCategoryResult.Success)
                    await _pointCategoryService.Update(PointCategoryDTO.Id, dto);
            }

            return result;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var result = await CreateUpdatePointCategory();
            switch (result)
            {
                case ValidatePointCategoryResult.EmptyCategory:
                    Utils.ShowMessages("Lỗi", "Mục điểm không được để trống", this);
                    txtCategory.Focus();
                    break;
                case ValidatePointCategoryResult.EmptyTitle:
                    Utils.ShowMessages("Lỗi", "Tiêu đề mục điểm không được để trống", this);
                    txtPointTitle.Focus();
                    break;
                case ValidatePointCategoryResult.InvalidMaxScore:
                    Utils.ShowMessages("Lỗi", "Điểm tối đa không hợp lệ", this);
                    txtMaxScore.Focus();
                    break;
                case ValidatePointCategoryResult.InvalidParent:
                    Utils.ShowMessages("Lỗi", "Danh mục cha không hợp lệ", this);
                    cboParentCategory.Focus();
                    break;
                case ValidatePointCategoryResult.Success:
                    Utils.ShowMessages("Thành công", Mode == FormMode.Create ? "Tạo mục điểm thành công" : "Cập nhật mục điểm thành công", this);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case ValidatePointCategoryResult.NotFound:
                    Utils.ShowMessages("Lỗi", "Mục điểm không tồn tại", this.ParentForm!);
                    break;
                default:
                    Utils.ShowMessages("Lỗi", "Thao tác không hợp lệ", this);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}