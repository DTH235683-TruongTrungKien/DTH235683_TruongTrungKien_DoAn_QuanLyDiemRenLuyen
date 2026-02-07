using QLDRL.Enums;

namespace QLDRL.DTOs.AppealDTOs
{
    public class UpdateAppealDTO
    {
        public int? ManagerUserId { get; set; }
        public AppealStatus Status { get; set; } = AppealStatus.Pending;
        public string? Response { get; set; }
    }
}
