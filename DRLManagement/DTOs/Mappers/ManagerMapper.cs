using QLDRL.DTOs.ManagerDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class ManagerMapper
    {
        public static ManagerDTO? ToManagerDTO(Manager manager)
        {
            if (manager == null) return null;
            return new ManagerDTO
            {
                UserId = manager.UserId,
                ManagerCode = manager.ManagerCode,
                Position = manager.Position,
                Department = manager.Department,
                FacultyName = manager.FacultyName
            };
        }

        public static Manager ToManager(CreateUpdateManagerDTO createManagerDTO)
        {
            var manager = new Manager
            {
                UserId = createManagerDTO.UserId,
                ManagerCode = createManagerDTO.ManagerCode,
                Position = createManagerDTO.Position,
                Department = createManagerDTO.Department,
                FacultyName = createManagerDTO.FacultyName,
            };

            return manager;
        }

        public static void MapUpdate(Manager manager, CreateUpdateManagerDTO updateManagerDTO)
        {
            manager.ManagerCode = updateManagerDTO.ManagerCode;
            manager.Position = updateManagerDTO.Position;
            manager.Department = updateManagerDTO.Department;
            manager.FacultyName = updateManagerDTO.FacultyName;
        }
    }
}