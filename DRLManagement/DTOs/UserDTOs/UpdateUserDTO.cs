namespace QLDRL.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; } 
        public DateOnly? Birthday { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public List<int>? RoleIds { get; set; } = new();
    }
}
