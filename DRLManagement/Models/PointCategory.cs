namespace QLDRL.Models
{
    public class PointCategory
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public double MaxScore { get; set; }
        public int? ParentId { get; set; }
        public PointCategory? Parent { get; set; }
        public ICollection<PointCategory> Children { get; set; } = new List<PointCategory>();
    }
}
