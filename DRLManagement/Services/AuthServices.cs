using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.UserDTOs;
using QLDRL.DTOs.StudentDTOs;
using QLDRL.Helpers;
using QLDRL.Enums;

namespace QLDRL.Services
{
    public class AuthServices
    {
        private readonly UserServices _userService;
        public AuthServices(UserServices userService)
        {
            _userService = userService;
        }
        public async Task<CurrentUserDTO?> Login(string email, string password)
        {
            var user = await _userService.GetByUserEmail(email);
            if (user == null || !Utils.VerifyPassword(password, user.HashedPassword))
            {
                return null;
            }
            var currentUser = UserMapper.ToCurrentUserDTO(user);
            return currentUser;
        }
        public async Task<ChangePasswordResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var user = await _userService.GetByUserEmail(changePasswordDTO.Email);
            if (user == null)
                return ChangePasswordResult.UserNotFound;

            if (!Utils.VerifyPassword(changePasswordDTO.OldPassword, user.HashedPassword))
                return ChangePasswordResult.OldPasswordIncorrect;

            if (!changePasswordDTO.NewPassword.Equals(changePasswordDTO.ConfirmPassword))
                return ChangePasswordResult.ConfirmPasswordIncorrect;

            await _userService.UpdatePassword(user, changePasswordDTO);

            return ChangePasswordResult.Success;
        }
    }
}
