using QLDRL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDRL.DTOs.ConfirmDTOs
{
    public class ConfirmHistoryDTO
    {
        public int Id { get; set; }
        public string SemesterName { get; set; } = string.Empty;
        public string RegisteredDate { get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
    }
}
