using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDRL.Models
{
    public enum Roles
    {
        Admin,
        Manager,
        Organizer,
        Student
    }
    internal class UserRole
    {
        public int Id { get; set; }
        public Roles Role { get; set; }
    }
}
