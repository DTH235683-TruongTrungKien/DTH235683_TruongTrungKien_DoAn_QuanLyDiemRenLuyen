namespace QLDRL.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public ICollection<PointDetail> Points { get; set; } = new List<PointDetail>();
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();
        public ICollection<Confirm> Confirms { get; set; } = new List<Confirm>();
    }
}
