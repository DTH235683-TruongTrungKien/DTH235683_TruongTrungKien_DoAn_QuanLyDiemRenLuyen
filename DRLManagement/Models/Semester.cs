namespace QLDRL.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ICollection<PointDetail> Points { get; set; } = new List<PointDetail>();
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<Confirm> Confirms { get; set; } = new List<Confirm>();
    }
}
