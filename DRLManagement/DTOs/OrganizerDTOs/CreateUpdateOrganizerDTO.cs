namespace QLDRL.DTOs.OrganizerDTOs
{
    public class CreateUpdateOrganizerDTO
    {
        public int UserId { get; set; }
        public string ClubName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
