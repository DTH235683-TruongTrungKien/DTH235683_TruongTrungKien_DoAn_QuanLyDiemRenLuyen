using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDRL.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string? EventDescription { get; set; } = string.Empty;
        public double AddPoint { get; set; }
        public double RemovePoint { get; set; }
    }
}
