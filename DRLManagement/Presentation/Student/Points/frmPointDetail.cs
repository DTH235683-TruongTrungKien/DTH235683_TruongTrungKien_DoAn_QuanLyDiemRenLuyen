using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.PointCategoryDTOs;
using QLDRL.Helpers;
using QLDRL.Presentation.Manager.PointCategory;
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

namespace QLDRL.Presentation.Student.Dialogs
{
    public partial class frmPointDetail : Form
    {
        private readonly PointCategoryService _pointCategoryService;
        private readonly Session _session;
        private List<PointDetailDTO> _points = new();

        public int SemesterId { get; set; }

        public frmPointDetail(
            PointCategoryService pointCategoryService,
            Session session)
        {
            InitializeComponent();
            _pointCategoryService = pointCategoryService;
            _session = session;
        }

        private async void frmPointDetail_Load(object sender, EventArgs e)
        {
            await LoadPoints();
            BuildTreeView();
        }

        private async Task LoadPoints()
        {
            var details = await _pointCategoryService
                .GetStudentPointDetails(SemesterId, _session.CurrentUser!.Id);

            _points = PointCategoryMapper.ToPointDetailListDTO(details);
            Utils.PrintDebug(_points);
        }
        private void BuildTreeView()
        {
            tvPointDetail.Nodes.Clear();
            CreateHeaderNode();

            var totalPoint = _points.First(x => x.Category == "Total");
            int pad = 100;

            var children = _points.Where(x => x.ParentId == totalPoint.PointCategoryId).ToList();
            foreach (var child in children)
            {
                var node = CreateNode(child, 75);
                node.NodeFont = new Font("Quicksand", 15, FontStyle.Bold);

                tvPointDetail.Nodes.Add(node);

                AddChildren(node, child.PointCategoryId, pad);
            }

            var totalTreeNode = CreateNode(totalPoint, 75);
            totalTreeNode.NodeFont = new Font("Quicksand", 15, FontStyle.Bold);
            tvPointDetail.Nodes.Add(totalTreeNode);

            tvPointDetail.ExpandAll();
        }

        private void AddChildren(TreeNode parentNode, int parentId, int pad)
        {
            var children = _points
                .Where(x => x.ParentId == parentId)
                .ToList();

            foreach (var child in children)
            {
                var node = CreateNode(child, pad);
                node.NodeFont = new Font("Quicksand", 12);

                parentNode.Nodes.Add(node);

                AddChildren(node, child.PointCategoryId, pad-7);
            }
        }
        private void CreateHeaderNode()
        {
            tvPointDetail.Nodes.Add(new TreeNode
            {
                Text = $"{"TIÊU CHÍ".PadRight(75)}{"TỐI ĐA".PadRight(20)}{"ĐIỂM".PadRight(60)}",
                NodeFont = new Font("Quicksand", 15, FontStyle.Bold),
                Tag = 0
            });
        }
        private TreeNode CreateNode(PointDetailDTO dto, int pad)
        {
            if(dto.Category == "Total")
            {
                return new TreeNode
                {
                    Text = $"{dto.Title.PadRight(pad)} " +
                       $"{dto.MaxScore.ToString().PadRight(20)} {dto.TotalScore.ToString().PadRight(60)}",
                    Tag = dto.PointCategoryId
                };
            }
            return new TreeNode
            {
                Text = $"{dto.Category}. {dto.Title.PadRight(pad-dto.Title.Length/2)} " +
                       $"{dto.MaxScore.ToString().PadRight(20)} {dto.TotalScore.ToString().PadRight(60)}",
                Tag = dto.PointCategoryId
            };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
