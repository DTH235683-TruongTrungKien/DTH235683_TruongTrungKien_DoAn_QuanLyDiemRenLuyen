namespace QLDRL.DTOs.UserDTOs
{
    public class CreateUpdateUserDTO
    {
        public int? Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Address {  get; set; } = string.Empty;    
        public List<int> RoleIds { get; set; } = new();
    }
}
