using QLDRL.DTOs.UserDTOs;
using QLDRL.Models;

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
                FullName = user.FullName,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleNames = string.Join(", ", user.Roles.Select(x => x.Name).ToList())
            };
            return userDTO;
        }
        public static List<UserDTO> ToUserDTOList(List<User> users)
        {
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleNames = string.Join(", ", user.Roles.Select(x => x.Name).ToList())
            }).ToList();
        }
        public static CurrentUserDTO ToCurrentUserDTO(User user)
        {
            var currentUserDTO = new CurrentUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Birthday = user.Birthday,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleNames = user.Roles.Select(x => x.Name).ToList(),
                Student = StudentMapper.ToStudentDTO(user.Student)
            };
            return currentUserDTO;
        }

        public static User ToUser(CreateUserDTO createUserDTO)
        {
            var user = new User()
            {
                Email = createUserDTO.Email,
                FullName = createUserDTO.FullName,
                Birthday = createUserDTO.Birthday,
                PhoneNumber = createUserDTO.PhoneNumber,
                Address = createUserDTO.Address,
            };
            return user;
        }
        public static void MapUpdate(User user, CreateUserDTO updateUserDTO)
        {
            if (updateUserDTO.Email != null) user.Email = updateUserDTO.Email;
            if (updateUserDTO.FullName != null) user.FullName = updateUserDTO.FullName;
            if (updateUserDTO.PhoneNumber != null) user.PhoneNumber = updateUserDTO.PhoneNumber;
            if (updateUserDTO.Address != null) user.Address = updateUserDTO.Address;
            user.Birthday = updateUserDTO.Birthday;
        }
        public static void MapEdit(User user, EditProfileDTO editUserDTO)
        {
            if (editUserDTO.FullName != null) user.FullName = editUserDTO.FullName;
            if (editUserDTO.PhoneNumber != null) user.PhoneNumber = editUserDTO.PhoneNumber;
            if (editUserDTO.Address != null) user.Address = editUserDTO.Address;
            user.Birthday = editUserDTO.Birthday;
        }
    }
}
