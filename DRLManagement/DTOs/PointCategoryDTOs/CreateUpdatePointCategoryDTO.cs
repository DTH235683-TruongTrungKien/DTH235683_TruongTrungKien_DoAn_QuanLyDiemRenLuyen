namespace QLDRL.DTOs.PointCategoryDTOs
{
    public class CreateUpdatePointCategoryDTO
    {
        public int? Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public double MaxScore { get; set; } = 0;
        public int? ParentId { get; set; }
    }
}
