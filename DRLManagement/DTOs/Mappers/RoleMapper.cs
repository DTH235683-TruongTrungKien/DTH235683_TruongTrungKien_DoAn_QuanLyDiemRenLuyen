using QLDRL.DTOs.RoleDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public class RoleMapper
    {
        public static RoleDTO ToRoleDTO(Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }
        public static List<RoleDTO> ToRoleDTOList(ICollection<Role> roles)
        {
            return roles.Select(r => ToRoleDTO(r)).ToList();
        }
    }
}
