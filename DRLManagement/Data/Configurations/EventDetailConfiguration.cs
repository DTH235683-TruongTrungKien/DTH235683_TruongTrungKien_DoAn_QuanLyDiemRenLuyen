using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class EventDetailConfiguration : IEntityTypeConfiguration<EventDetail>
    {
        public void Configure(EntityTypeBuilder<EventDetail> builder)
        {
            builder.HasKey(x => new { x.EventId, x.PointCategoryId });
        }
    }
}
