using QLDRL.DTOs.AdminDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class AdminMapper
    {
        public static AdminDTO? ToAdminDTO(Admin admin)
        {
            if (admin == null) return null;

            return new AdminDTO
            {
                UserId = admin.UserId,
                Permission = admin.IsSuperAdmin ? "Quản trị viên cấp cao" : "Quản trị viên",
                Department = admin.Department
            };
        }

        public static Admin ToAdmin(CreateUpdateAdminDTO createAdminDTO)
        {
            var admin = new Admin
            {
                UserId = createAdminDTO.UserId,
                IsSuperAdmin = createAdminDTO.IsSuperAdmin,
                Department = createAdminDTO.Department
            };

            return admin;
        }

        public static void MapUpdate(Admin admin, CreateUpdateAdminDTO updateAdminDTO)
        {
            admin.IsSuperAdmin = updateAdminDTO.IsSuperAdmin;
            admin.Department = updateAdminDTO.Department;
        }
    }
}