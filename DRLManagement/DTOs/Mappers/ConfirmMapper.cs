using QLDRL.DTOs.ConfirmDTOs;
using QLDRL.Enums;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class ConfirmMapper
    {
        public static List<ConfirmHistoryDTO> ToConfirmHistoryDTOList(List<Confirm> confirmList)
        {
            return confirmList.Select (confirm => new ConfirmHistoryDTO
            {
                SemesterName = confirm.Semester.Name,
                RegisteredDate = confirm.RegisteredDate.ToString(),
                Status = confirm.Status switch
                {
                    ConfirmStatus.Pending => "Đang xử lý",
                    ConfirmStatus.Approved => "Đã duyệt",
                    ConfirmStatus.Rejected => "Đã từ chối",
                    _ => confirm.Status.ToString(),
                }
            }).ToList();
        }
    }
}
