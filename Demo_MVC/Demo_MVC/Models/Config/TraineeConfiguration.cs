using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_MVC.Models.Config
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Image).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Level).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.HasOne(x => x.Department).WithMany(x => x.Trainees).HasForeignKey(x => x.Dept_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Trainees");
        }
    }
}
