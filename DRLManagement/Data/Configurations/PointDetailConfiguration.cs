using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class PointDetailConfiguration : IEntityTypeConfiguration<PointDetail>
    {
        public void Configure(EntityTypeBuilder<PointDetail> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.SemesterId, x.CategoryId });
        }
    }
}
