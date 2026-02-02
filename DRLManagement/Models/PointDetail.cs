namespace QLDRL.Models
{
    public class PointDetail
    {
        public int CategoryId { get; set; }
        public PointCategory Category { get; set; } = null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public double TotalScore { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;


    }
}
