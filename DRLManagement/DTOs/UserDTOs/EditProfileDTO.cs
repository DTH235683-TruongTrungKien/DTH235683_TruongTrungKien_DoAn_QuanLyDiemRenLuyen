namespace QLDRL.DTOs.UserDTOs
{
    public class EditProfileDTO
    {
        public string? FullName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
    }
}
