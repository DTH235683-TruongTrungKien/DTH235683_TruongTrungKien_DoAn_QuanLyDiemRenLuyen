using QLDRL.DTOs.UserDTOs;
using QLDRL.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLDRL.DTOs.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(User user)
        {
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Roles = user.UserRoles.Select(x => x.Role.Name).ToList(),
            };
            return userDTO;
        }

        public static User ToUser(CreateUpdateUserDTO createUserDTO)
        {
            var user = new User()
            {
                Id = createUserDTO.Id,
                Email = createUserDTO.Email,
                Name = createUserDTO.Name,
            };
            return user;
        }
        public static void MapUpdate(User user, CreateUpdateUserDTO updateUserDTO)
        {
            user.Email = updateUserDTO.Email;
            user.Name = updateUserDTO.Name;
        }
    }
}
