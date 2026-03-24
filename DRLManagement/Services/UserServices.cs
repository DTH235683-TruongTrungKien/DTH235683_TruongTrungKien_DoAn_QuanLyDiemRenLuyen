using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.UserDTOs;
using QLDRL.Models;
using QLDRL.DTOs.Mappers;
using QLDRL.Helpers;
using System.Text.RegularExpressions;
using QLDRL.Enums;

namespace QLDRL.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }
        public bool CheckRole(User user, string roleName)
        {
            return user.Roles.Any(x => x.Name == roleName);
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users
                .Include(x => x.Roles)
                .Include(x => x.Admin)
                .Include(x => x.Manager)
                .Include(x => x.Organizer)
                .Include(x => x.Student)
                .ThenInclude(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .ToListAsync();
        }
        public async Task<User?> GetById(int id)
        {
            return await _context.Users
                .Include(x => x.Roles)
                .Include(x => x.Admin)
                .Include(x => x.Manager)
                .Include(x => x.Organizer)
                .Include(x => x.Student)
                .ThenInclude(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User?> GetByUserEmail(string email)
        {
            return await _context.Users
                .Include(x => x.Roles)
                .Include(x => x.Admin)
                .Include(x => x.Manager)
                .Include(x => x.Organizer)
                .Include(x => x.Student)
                .ThenInclude(x => x.StudentClass)
                .ThenInclude(x => x.Major)
                .ThenInclude(x => x.Faculty)
                .FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<ValidateUserResult> Create(CreateUserDTO createUserDTO)
        {
            if (string.IsNullOrWhiteSpace(createUserDTO.Email))
                return ValidateUserResult.EmptyEmail;

            if (!Regex.IsMatch(createUserDTO.Email, @"^[^@\s]+@[^@\s]+$"))
                return ValidateUserResult.InvalidEmail;

            if (string.IsNullOrWhiteSpace(createUserDTO.FullName))
                return ValidateUserResult.EmptyName;

            if (createUserDTO.Birthday == default)
                return ValidateUserResult.InvalidBirthday;

            if (!string.IsNullOrWhiteSpace(createUserDTO.PhoneNumber) &&
                !Regex.IsMatch(createUserDTO.PhoneNumber, @"^[0-9]{9,11}$"))
                return ValidateUserResult.InvalidPhoneNumber;

            if (string.IsNullOrWhiteSpace(createUserDTO.Password))
                return ValidateUserResult.EmptyPassword;

            if (createUserDTO.Password.Length < 5)
                return ValidateUserResult.ShortPassword;

            if (createUserDTO.RoleIds.Count < 1)
                return ValidateUserResult.NoRoleSelected;

            User user = UserMapper.ToUser(createUserDTO);
            user.HashedPassword = Utils.HashPassword(createUserDTO.Password);
            var roles = await _context.Roles
                .Where(x => createUserDTO.RoleIds.Contains(x.Id))
                .ToListAsync();
            user.Roles = roles;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return ValidateUserResult.Success;
        }
        public async Task<ValidateUserResult> Update(User user, CreateUserDTO updateUserDTO)
        {
            if (string.IsNullOrWhiteSpace(updateUserDTO.Email))
                return ValidateUserResult.EmptyEmail;

            if (!Regex.IsMatch(updateUserDTO.Email, @"^[^@\s]+@[^@\s]+$"))
                return ValidateUserResult.InvalidEmail;

            if (string.IsNullOrWhiteSpace(updateUserDTO.FullName))
                return ValidateUserResult.EmptyName;

            if (updateUserDTO.Birthday == default)
                return ValidateUserResult.InvalidBirthday;

            if (!string.IsNullOrWhiteSpace(updateUserDTO.PhoneNumber) &&
                !Regex.IsMatch(updateUserDTO.PhoneNumber, @"^[0-9]{9,11}$"))
                return ValidateUserResult.InvalidPhoneNumber;

            if (string.IsNullOrWhiteSpace(updateUserDTO.Password))
                return ValidateUserResult.EmptyPassword;

            if (updateUserDTO.Password.Length < 5)
                return ValidateUserResult.ShortPassword;
            UserMapper.MapUpdate(user, updateUserDTO);
            if (!string.IsNullOrWhiteSpace(updateUserDTO.Password))
            {
                user.HashedPassword = Utils.HashPassword(updateUserDTO.Password);
            }
            var roleIds = updateUserDTO.RoleIds;
            var roles = await _context.Roles
                .Where(x => roleIds.Contains(x.Id))
                .ToListAsync();
            var oldRoles = user.Roles.Where(x => !roleIds.Contains(x.Id)).ToList();
            foreach (var role in oldRoles)
            {
                user.Roles.Remove(role);
            }
            var newRoles = roles.Where(r => !user.Roles.Any(ur => ur.Id == r.Id)).ToList();
            foreach (var role in newRoles)
            {
                user.Roles.Add(role);
            }
            await _context.SaveChangesAsync();
            return ValidateUserResult.Success;
        }
        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        // For users

        public async Task EditProfile(User user, EditProfileDTO editProfileDTO)
        {
            UserMapper.MapEdit(user, editProfileDTO);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePassword(User user, ChangePasswordDTO changePasswordDTO)
        {
            user.HashedPassword = Utils.HashPassword(changePasswordDTO.NewPassword);
            await _context.SaveChangesAsync();
        }
    }
}
