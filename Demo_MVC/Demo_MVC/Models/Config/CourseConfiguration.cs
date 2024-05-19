using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_MVC.Models.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Degree).IsRequired();
            builder.Property(x => x.MinDegree).IsRequired();
            builder.HasOne(x => x.Department).WithMany(x => x.Courses).HasForeignKey(x => x.Dept_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Courses");
        }
    }
}
