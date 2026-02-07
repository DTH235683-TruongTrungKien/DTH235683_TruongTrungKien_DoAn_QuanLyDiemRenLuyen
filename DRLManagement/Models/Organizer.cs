using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLDRL.Models
{
    public class Organizer
    {
        [Key]
        public int UserId { get; set; }
        public string ClubName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int TotalCreatedEvents { get; set; } = 0;
        public int TotalActiveEvents { get; set; } = 0;
        public User User { get; set; } = null!;
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
