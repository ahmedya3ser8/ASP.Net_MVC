using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_MVC.Models.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.Property(x=> x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
			builder.Property(x=> x.Price).HasPrecision(18,2);
			builder.Property(x=> x.Address).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
			builder.Property(x=> x.Image).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
			builder.HasOne(x => x.Department).WithMany(x => x.Employees).HasForeignKey(x => x.Dept_Id).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
			builder.ToTable("Employees");
		}
	}
}
