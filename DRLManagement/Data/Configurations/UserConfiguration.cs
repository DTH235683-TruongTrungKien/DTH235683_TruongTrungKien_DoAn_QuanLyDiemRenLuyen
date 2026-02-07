using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x => x.Admin)
                .WithOne(x => x.User)
                .HasForeignKey<Admin>(x => x.UserId);

            builder.HasOne(x => x.Manager)
                .WithOne(x => x.User)
                .HasForeignKey<Manager>(x => x.UserId);

            builder.HasOne(x => x.Organizer)
                .WithOne(x => x.User)
                .HasForeignKey<Organizer>(x => x.UserId);

            builder.HasOne(x => x.Student)
                .WithOne(x => x.User)
                .HasForeignKey<Student>(x => x.UserId);
        }
    }
}
