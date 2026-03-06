using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.AdminDTOs;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
using QLDRL.Models;

public class AdminService
{
    private readonly AppDbContext _context;

    public AdminService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Admin>> GetAll()
    {
        return await _context.Admins.ToListAsync();
    }

    public async Task<Admin?> GetById(int? id)
    {
        if (id == null)
            return null;

        return await _context.Admins
            .FirstOrDefaultAsync(x => x.UserId == id);
    }

    public ValidateAdminResult ValidateAdmin(CreateUpdateAdminDTO adminDTO)
    {
        if (string.IsNullOrWhiteSpace(adminDTO.Department))
            return ValidateAdminResult.EmptyDepartment;

        return ValidateAdminResult.Success;
    }

    public async Task<int> Create(CreateUpdateAdminDTO createAdminDTO, User user)
    {
        var admin = AdminMapper.ToAdmin(createAdminDTO);

        await _context.Admins.AddAsync(admin);
        user.Admin = admin;
        admin.User = user;

        await _context.SaveChangesAsync();
        return admin.UserId;
    }

    public async Task<int> Update(Admin admin, CreateUpdateAdminDTO updateAdminDTO)
    {
        AdminMapper.MapUpdate(admin, updateAdminDTO);

        await _context.SaveChangesAsync();
        return admin.UserId;
    }

    public async Task<bool> Delete(int? userId)
    {
        if (userId == null)
            return false;

        var admin = await GetById(userId);
        if (admin == null)
            return false;

        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
        return true;
    }
}