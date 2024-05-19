using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo_MVC.Models.Config
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property(x=> x.Name).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
			builder.Property(x=> x.ManagerName).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
			builder.ToTable("Departments");
		}
	}
}
