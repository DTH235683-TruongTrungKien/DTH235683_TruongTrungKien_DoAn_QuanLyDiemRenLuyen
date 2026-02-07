namespace QLDRL.Models
{
    public class StudentClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int MajorId { get; set; }
        public Major Major { get; set; } = null!;
    }
}
