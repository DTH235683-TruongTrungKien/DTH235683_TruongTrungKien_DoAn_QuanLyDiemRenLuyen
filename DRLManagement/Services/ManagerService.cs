using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.ManagerDTOs;
using QLDRL.DTOs.Mappers;
using QLDRL.Enums;
using QLDRL.Models;

public class ManagerService
{
    private readonly AppDbContext _context;

    public ManagerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Manager>> GetAll()
    {
        return await _context.Managers.ToListAsync();
    }

    public async Task<Manager?> GetById(int? id)
    {
        if (id == null)
            return null;

        return await _context.Managers.FirstOrDefaultAsync(x => x.UserId == id);
    }

    public ValidateManagerResult ValidateManager(CreateUpdateManagerDTO managerDTO)
    {
        if (string.IsNullOrWhiteSpace(managerDTO.ManagerCode))
            return ValidateManagerResult.EmptyCode;

        if (string.IsNullOrWhiteSpace(managerDTO.Position))
            return ValidateManagerResult.EmptyPosition;

        if (string.IsNullOrWhiteSpace(managerDTO.Department))
            return ValidateManagerResult.EmptyDepartment;

        if (string.IsNullOrWhiteSpace(managerDTO.FacultyName))
            return ValidateManagerResult.InvalidFaculty;

        return ValidateManagerResult.Success;
    }

    public async Task<int> Create(CreateUpdateManagerDTO createManagerDTO, User user)
    {
        var manager = ManagerMapper.ToManager(createManagerDTO);

        await _context.Managers.AddAsync(manager);
        user.Manager = manager;
        manager.User = user;

        await _context.SaveChangesAsync();
        return manager.UserId;
    }

    public async Task<int> Update(Manager manager, CreateUpdateManagerDTO updateManagerDTO)
    {
        ManagerMapper.MapUpdate(manager, updateManagerDTO);

        await _context.SaveChangesAsync();
        return manager.UserId;
    }

    public async Task<bool> Delete(int? userId)
    {
        if (userId == null)
            return false;

        var manager = await GetById(userId);
        if (manager == null)
            return false;

        _context.Managers.Remove(manager);
        await _context.SaveChangesAsync();
        return true;
    }
}