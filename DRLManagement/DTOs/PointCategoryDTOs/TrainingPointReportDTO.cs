namespace QLDRL.DTOs.PointCategoryDTOs
{
    public class TrainingPointReportDTO
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double TotalScore { get; set; }
        public double MaxScore { get; set; }
    }
}