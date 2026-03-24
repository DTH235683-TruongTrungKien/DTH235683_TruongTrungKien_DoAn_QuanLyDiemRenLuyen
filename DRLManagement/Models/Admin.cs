using System.ComponentModel.DataAnnotations;

namespace QLDRL.Models
{
    public class Admin
    {
        public int UserId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public User User { get; set; } = null!;
    }
}
