namespace QLDRL.Models
{
    public class PointDetail
    {
        public int PointCategoryId { get; set; }
        public PointCategory PointCategory { get; set; } = null!;
        public int StudentUserId { get; set; }
        public Student Student { get; set; } = null!;
        public double TotalScore { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
    }
}
