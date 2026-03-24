using System.ComponentModel.DataAnnotations;

namespace QLDRL.Models
{
    public class Organizer
    {
        public int UserId { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public User User { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
