using QLDRL.Enums;
using QLDRL.Models;

namespace QLDRL.DTOs.EventDTOs
{
    public class EventRegistrationDTO
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string SemesterName {  get; set; } = string.Empty;
        public string RegisteredDate {  get; set; } = string.Empty;
        public string StartDate {  get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public double Score { get; set; } = 0;
        public AttendStatus AttendStatus {  get; set; } 
        
    }
}
