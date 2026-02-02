using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLDRL.Models;

namespace QLDRL.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Student)
                .HasForeignKey<Student>(x => x.UserId);
        }
    }
}
