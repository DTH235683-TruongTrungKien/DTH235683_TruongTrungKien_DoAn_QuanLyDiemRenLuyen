namespace QLDRL.DTOs.AdminDTOs
{
    public class CreateUpdateAdminDTO
    {
        public int UserId { get; set; }
        public bool IsSuperAdmin { get; set; } = false;
        public string Department { get; set; } = string.Empty;
    }
}
