using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Manager)
                .HasForeignKey<Manager>(x => x.UserId);
        }
    }
}
