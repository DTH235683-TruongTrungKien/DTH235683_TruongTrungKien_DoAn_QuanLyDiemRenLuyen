namespace QLDRL.Models
{
    public class EventDetail
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;
        public int PointCategoryId { get; set; }
        public PointCategory PointCategory { get; set; } = null!;
        public double AddPoint { get; set; } = 0;
        public double RemovePoint { get; set; } = 0;
    }
}
