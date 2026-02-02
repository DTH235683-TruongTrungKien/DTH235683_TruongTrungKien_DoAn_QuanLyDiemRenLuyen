using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class OrganizerConfiguration : IEntityTypeConfiguration<Organizer>
    {
        public void Configure(EntityTypeBuilder<Organizer> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Organizer)
                .HasForeignKey<Organizer>(x => x.UserId);
        }
    }
}
