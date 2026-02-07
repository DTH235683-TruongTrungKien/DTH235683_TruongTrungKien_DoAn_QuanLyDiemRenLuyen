using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class PointCategoryConfiguration : IEntityTypeConfiguration<PointCategory>
    {
        public void Configure(EntityTypeBuilder<PointCategory> builder)
        {
            builder.HasOne(pc => pc.Parent)
            .WithMany(pc => pc.Children)
            .HasForeignKey(pc => pc.ParentId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
