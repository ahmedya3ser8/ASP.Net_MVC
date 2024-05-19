using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_MVC.Models.Config
{
    public class CourseResultConfiguration : IEntityTypeConfiguration<CourseResult>
    {
        public void Configure(EntityTypeBuilder<CourseResult> builder)
        {
            builder.Property(x => x.Degree).IsRequired();
            builder.HasOne(x => x.Course).WithMany(x => x.CourseResults).HasForeignKey(x => x.Course_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Trainee).WithMany(x => x.CourseResults).HasForeignKey(x => x.Trainee_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("CourseResults");
        }
    }
}
