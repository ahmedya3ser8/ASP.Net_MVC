using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_MVC.Models.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Salary).HasPrecision(18, 2);
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Image).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.Department).WithMany(x => x.Instructors).HasForeignKey(x => x.Dept_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Course).WithMany(x => x.Instructors).HasForeignKey(x => x.Course_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Instructors");
        }
    }
}
