using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Admin)
                .HasForeignKey<Admin>(x => x.UserId);
        }
    }
}
