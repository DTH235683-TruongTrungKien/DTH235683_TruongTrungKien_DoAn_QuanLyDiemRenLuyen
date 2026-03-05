namespace QLDRL.Models
{
    public class User
    {
        public int Id {  get; set; }
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Birthday { get; set; }
        public Admin? Admin { get; set; }
        public Manager? Manager { get; set; }
        public Organizer? Organizer { get; set; }
        public Student? Student { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}