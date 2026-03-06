using Microsoft.EntityFrameworkCore;
using QLDRL.Data;
using QLDRL.DTOs.Mappers;
using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.Enums;
using QLDRL.Models;

public class OrganizerService
{
    private readonly AppDbContext _context;

    public OrganizerService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Organizer>> GetAll()
    {
        return await _context.Organizers
            .Include(x => x.Events)
            .ToListAsync();
    }

    public async Task<Organizer?> GetById(int? id)
    {
        if (id == null)
            return null;

        return await _context.Organizers
            .Include(x => x.Events)
            .FirstOrDefaultAsync(x => x.UserId == id);
    }

    public ValidateOrganizerResult ValidateOrganizer(CreateUpdateOrganizerDTO organizerDTO)
    {
        if (string.IsNullOrWhiteSpace(organizerDTO.ClubName))
            return ValidateOrganizerResult.EmptyClubName;

        if (string.IsNullOrWhiteSpace(organizerDTO.Position))
            return ValidateOrganizerResult.EmptyPosition;

        return ValidateOrganizerResult.Success;
    }

    public async Task<int> Create(CreateUpdateOrganizerDTO createOrganizerDTO, User user)
    {
        var organizer = OrganizerMapper.ToOrganizer(createOrganizerDTO);

        await _context.Organizers.AddAsync(organizer);
        user.Organizer = organizer;
        organizer.User = user;

        await _context.SaveChangesAsync();
        return organizer.UserId;
    }

    public async Task<int> Update(Organizer organizer, CreateUpdateOrganizerDTO updateOrganizerDTO)
    {
        OrganizerMapper.MapUpdate(organizer, updateOrganizerDTO);

        await _context.SaveChangesAsync();
        return organizer.UserId;
    }

    public async Task<bool> Delete(int? userId)
    {
        if (userId == null)
            return false;

        var organizer = await GetById(userId);
        if (organizer == null)
            return false;

        _context.Organizers.Remove(organizer);
        await _context.SaveChangesAsync();
        return true;
    }
}