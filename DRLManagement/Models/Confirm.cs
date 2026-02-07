using QLDRL.Enums;

namespace QLDRL.Models
{
    public class Confirm
    {
        public int Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }
        public ConfirmStatus Status { get; set; } = ConfirmStatus.Pending;
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
        public int StudentUserId { get; set; }
        public Student Student { get; set; } = null!;
        public int? ManagerUserId { get; set; }
        public Manager? Manager { get; set; } = null!;
    }
}
