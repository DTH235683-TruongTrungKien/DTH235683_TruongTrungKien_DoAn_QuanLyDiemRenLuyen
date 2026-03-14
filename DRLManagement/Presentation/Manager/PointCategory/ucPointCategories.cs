using Microsoft.Extensions.DependencyInjection;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Enums;
using QLDRL.Helpers;
using QLDRL.Services;

namespace QLDRL.Presentation.Manager.PointCategory
{
    public partial class ucPointCategories : UserControl
    {
        private readonly PointCategoryService _pointCategoryService;
        private readonly IServiceProvider _serviceProvider;

        public ucPointCategories(PointCategoryService pointCategoryService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _pointCategoryService = pointCategoryService;
            _serviceProvider = serviceProvider;
        }

        private async void ucPointCategories_Load(object sender, EventArgs e)
        {

            await BuildTreeView();
            tvPointCategories.ItemHeight = 50;
            tvPointCategories.Scrollable = true;
        }

        private async Task BuildTreeView()
        {
            var rootPoints = await _pointCategoryService.GetAllRoots();
            var pointsDTO = PointCategoryMapper.ToPointCategoryDTOList(rootPoints);
            tvPointCategories.Nodes.Clear();
            CreateHeaderNode();
            int pad = 100;

            var totalPoint = pointsDTO.First(x => x.Category == "Total");

            var childrenPoints = await _pointCategoryService.GetAllByParentId(totalPoint.Id);
            var childrenDTO = PointCategoryMapper.ToPointCategoryDTOList(childrenPoints);

            foreach (var child in childrenDTO)
            {
                var node = CreateNode(child, 75);
                node.NodeFont = new Font("Quicksand", 15, FontStyle.Bold);
                tvPointCategories.Nodes.Add(node);

                await AddChildren(node, child.Id, pad);
            }

            var totalNode = CreateNode(totalPoint, 75);
            totalNode.NodeFont = new Font("Quicksand", 15, FontStyle.Bold);
            tvPointCategories.Nodes.Add(totalNode);

            tvPointCategories.ExpandAll();
        }

        private async Task AddChildren(TreeNode parentNode, int parentId, int pad)
        {
            var childrenPoints = await _pointCategoryService.GetAllByParentId(parentId);
            var pointsDTO = PointCategoryMapper.ToPointCategoryDTOList(childrenPoints);

            foreach (var point in pointsDTO)
            {
                var node = CreateNode(point, pad);
                node.NodeFont = new Font("Quicksand", 12);
                parentNode.Nodes.Add(node);

                await AddChildren(node, point.Id, pad-7);
            }
        }
        private void CreateHeaderNode()
        {
            tvPointCategories.Nodes.Add(new TreeNode
            {
                Text = $"{"MỤC ĐIỂM".PadRight(75)}{"TỐI ĐA".PadRight(60)}",
                NodeFont = new Font("Quicksand", 15, FontStyle.Bold),
                Tag = 0
            });
        }
        private TreeNode CreateNode(PointCategoryDTO pc, int pad)
        {
            if (pc.Category == "Total")
            {
                return new TreeNode
                {
                    Text = $"{pc.Title.PadRight(pad)} " +
                       $"{pc.MaxScore.ToString().PadRight(100)}",
                    Tag = pc.Id
                };
            }
            return new TreeNode
            {
                Text = $"{pc.Category}. {pc.Title.PadRight(pad-pc.Title.Length/2)} {pc.MaxScore.ToString().PadRight(60)}",
                Tag = pc.Id
            };

        }

        private async void btnAddPoint_Click(object sender, EventArgs e)
        {
            var pointForm = _serviceProvider.GetRequiredService<frmAddUpdatePointCategories>();
            pointForm.Mode = FormMode.Create;
            var dialogResult = pointForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                await BuildTreeView();
            }
        }

        private async void btnUpdatePoint_Click(object sender, EventArgs e)
        {
            var selectedNode = tvPointCategories.SelectedNode;
            if (selectedNode == null)
            {
                Utils.ShowMessages("Thông báo", "Vui lòng chọn mục điểm", this.ParentForm!);
                return;
            }
            int id = Convert.ToInt32(selectedNode.Tag);
            if(id == 0)
            {
                Utils.ShowMessages("Lỗi", "Mục điểm không tồn tại", this.ParentForm!);
                return;
            }
            var point = await _pointCategoryService.GetById(id);
            var pointDTO = PointCategoryMapper.ToPointCategoryDTO(point);

            var pointForm = _serviceProvider.GetRequiredService<frmAddUpdatePointCategories>();
            pointForm.Mode = FormMode.Update;
            pointForm.PointCategoryDTO = pointDTO;

            var dialogResult = pointForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                await BuildTreeView();
            }
        }

        private async void btnDeletePoint_Click(object sender, EventArgs e)
        {
            var selectedNode = tvPointCategories.SelectedNode;
            if (selectedNode == null)
            {
                Utils.ShowMessages("Thông báo", "Vui lòng chọn mục điểm", this.ParentForm!);
                return;
            }

            var dialogResult = Utils.ConfirmDialog("Xóa mục điểm", "Bạn có chắc chắn muốn xóa mục điểm này?", this.ParentForm!);
            if (dialogResult == DialogResult.Yes)
            {
                int id = Convert.ToInt32(selectedNode.Tag);

                var result = await _pointCategoryService.Delete(id);
                if (result == ValidatePointCategoryResult.NotFound)
                {
                    Utils.ShowMessages("Lỗi", "Mục điểm không tồn tại", this.ParentForm!);
                }
                else if(result == ValidatePointCategoryResult.HasChildren)
                {
                    Utils.ShowMessages("Thông báo", "Không thể xóa vì mục điểm này còn chứa các mục khác", this.ParentForm!);
                }
                else
                {
                    Utils.ShowMessages("Thông báo", "Xóa mục điểm thành công", this.ParentForm!);
                    await BuildTreeView();
                }
            }
        }
    }
}