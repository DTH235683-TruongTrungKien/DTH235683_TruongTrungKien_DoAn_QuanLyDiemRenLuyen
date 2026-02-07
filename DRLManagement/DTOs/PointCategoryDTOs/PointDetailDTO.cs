namespace QLDRL.DTOs.PointCategoryDTOs
{
    public class PointDetailDTO
    {
        public int PointCategoryId { get; set; }
        public int SemesterId { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public double TotalScore { get; set; }
        public double MaxScore { get; set; } = 0;
        public int? ParentId { get; set; }
    }
}
