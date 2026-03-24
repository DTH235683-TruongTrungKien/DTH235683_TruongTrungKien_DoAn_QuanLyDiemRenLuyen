using System.ComponentModel.DataAnnotations;

namespace QLDRL.Models
{
    public class Manager
    {
        public int UserId { get; set; }
        public DateTime AssignedDate {  get; set; } = DateTime.Now;
        public User User { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<Appeal> Appeals { get; set; } = new List<Appeal>();
        public ICollection<Confirm> Confirms { get; set; } = new List<Confirm>();
    }
}
