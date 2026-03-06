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
        public async Task<List<User>> GetByStatus(bool isActive)
        {
            return await _context.Users
                .Where(x => x.IsActive == isActive)
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
        public async Task<User?> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
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
        public async Task<List<User>> SearchUsers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetByStatus(true);

            keyword = keyword.ToLower();
            return await _context.Users
                .Where(x => x.IsActive && x.FullName.ToLower().Contains(keyword))
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

        public async Task<List<Role>> GetRolesByUserId(int id)
        {
            return await _context.Users
                .Where(x => x.Id == id)
                .SelectMany(x => x.Roles)
                .ToListAsync();
                
        }
        public async Task<bool> ExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }
        public async Task<bool> ValidateEmail(int? id, string email)
        {
            return !await _context.Users.AnyAsync(x => x.Email == email && (id == null || id == 0 || x.Id != id));
        }
        public async Task<ValidateUserResult> ValidateUser(CreateUpdateUserDTO userDTO)
        {

            if (string.IsNullOrWhiteSpace(userDTO.Email))
                return ValidateUserResult.EmptyEmail;

            if (!Regex.IsMatch(userDTO.Email, @"^[^@\s]+@[^@\s]+$"))
                return ValidateUserResult.InvalidEmail;

            if (!await ValidateEmail(userDTO.Id, userDTO.Email))
                return ValidateUserResult.ExistedEmail;

            if (string.IsNullOrWhiteSpace(userDTO.FullName))
                return ValidateUserResult.EmptyName;

            if (userDTO.Birthday == default)
                return ValidateUserResult.InvalidBirthday;

            if (!string.IsNullOrWhiteSpace(userDTO.PhoneNumber) &&
                !Regex.IsMatch(userDTO.PhoneNumber, @"^[0-9]{9,11}$"))
                return ValidateUserResult.InvalidPhoneNumber;

            if (string.IsNullOrWhiteSpace(userDTO.Password) && userDTO.Id == null)
                return ValidateUserResult.EmptyPassword;

            if (userDTO.Password.Length < 6 && userDTO.Id == null)
                return ValidateUserResult.ShortPassword;

            if (userDTO.RoleIds.Count < 1)
                return ValidateUserResult.NoRoleSelected;
            return ValidateUserResult.Success;  
        }
        public async Task<int> Create(CreateUpdateUserDTO CreateUpdateUserDTO)
        {
            User user = UserMapper.ToUser(CreateUpdateUserDTO);
            var roles = await _context.Roles
                .Where(x => CreateUpdateUserDTO.RoleIds.Contains(x.Id))
                .ToListAsync();
            user.Roles = roles;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> Update(User user, CreateUpdateUserDTO updateUserDTO)
        {
            UserMapper.MapUpdate(user, updateUserDTO);
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
            return user.Id;
        }
        public async Task SoftDelete(int id)
        {
            var user = await GetById(id);
            user.IsActive = false;
            await _context.SaveChangesAsync();
        }
        public async Task HardDelete(int id)
        {
            var user = await GetById(id);
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
