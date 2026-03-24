namespace QLDRL.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;    
        public List<int> RoleIds { get; set; } = new();
    }
}
