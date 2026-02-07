using QLDRL.DTOs.OrganizerDTOs;
using QLDRL.Models;

namespace QLDRL.DTOs.Mappers
{
    public static class OrganizerMapper
    {
        public static OrganizerDTO? ToOrganizerDTO(Organizer organizer)
        {
            if (organizer == null) return null;
            return new OrganizerDTO
            {
                UserId = organizer.UserId,
                ClubName = organizer.ClubName,
                Position = organizer.Position
            };
        }

        public static Organizer ToOrganizer(CreateUpdateOrganizerDTO createOrganizerDTO)
        {
            var organizer = new Organizer
            {
                UserId = createOrganizerDTO.UserId,
                ClubName = createOrganizerDTO.ClubName,
                Position = createOrganizerDTO.Position,
                TotalCreatedEvents = 0,
                TotalActiveEvents = 0
            };

            return organizer;
        }

        public static void MapUpdate(Organizer organizer, CreateUpdateOrganizerDTO updateOrganizerDTO)
        {
            organizer.ClubName = updateOrganizerDTO.ClubName;
            organizer.Position = updateOrganizerDTO.Position;
        }
    }
}