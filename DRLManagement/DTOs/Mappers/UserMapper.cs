using QLDRL.DTOs.UserDTOs;
using QLDRL.Helpers;
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
                Birthday = user.Birthday.ToString(),
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleNames = string.Join(", ", user.Roles.Select(x => x.Name).ToList()),
                Status = user.IsActive ? "Hoạt động" : "Ngừng hoạt động"
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
                Birthday = user.Birthday.ToString(),
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
                Birthday = user.Birthday.ToString(),
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleNames = user.Roles.Select(x => x.Name).ToList(),
                Admin = AdminMapper.ToAdminDTO(user.Admin!),
                Manager = ManagerMapper.ToManagerDTO(user.Manager!),
                Organizer = OrganizerMapper.ToOrganizerDTO(user.Organizer!),
                Student = StudentMapper.ToStudentDTO(user.Student!)
            };
            return currentUserDTO;
        }

        public static User ToUser(CreateUpdateUserDTO createUserDTO)
        {
            var user = new User()
            {
                Email = createUserDTO.Email,
                HashedPassword = Utils.HashPassword(createUserDTO.Password),
                FullName = createUserDTO.FullName,
                Birthday = Utils.ConvertDate(createUserDTO.Birthday),
                PhoneNumber = createUserDTO.PhoneNumber,
                Address = createUserDTO.Address,
            };
            return user;
        }
        public static void MapUpdate(User user, CreateUpdateUserDTO updateUserDTO)
        {
            user.Email = updateUserDTO.Email;
            user.FullName = updateUserDTO.FullName;
            user.PhoneNumber = updateUserDTO.PhoneNumber;
            user.Address = updateUserDTO.Address;
            user.Birthday = Utils.ConvertDate(updateUserDTO.Birthday);
        }
        public static void MapEdit(User user, EditProfileDTO editUserDTO)
        {
            user.FullName = editUserDTO.FullName;
            if (editUserDTO.PhoneNumber != null) user.PhoneNumber = editUserDTO.PhoneNumber;
            if (editUserDTO.Address != null) user.Address = editUserDTO.Address;
            user.Birthday = Utils.ConvertDate(editUserDTO.Birthday);
        }
    }
}
