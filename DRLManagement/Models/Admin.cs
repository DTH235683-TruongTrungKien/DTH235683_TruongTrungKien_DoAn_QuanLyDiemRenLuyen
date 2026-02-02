namespace QLDRL.Models
{
    public class Admin
    {
        public int UserId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public User User { get; set; } = null!;
    }
}
