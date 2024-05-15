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
			builder.HasData(LoadDepartments());
		}

		private static List<Department> LoadDepartments()
		{
			return new List<Department>
			{
				new Department { Id = 1, Name = "SD", ManagerName = "Ali"},
				new Department { Id = 2, Name = "Frontend", ManagerName = "Eman"},
				new Department { Id = 3, Name = "Backend", ManagerName = "Ahmed"}
			};
		}
	}
}
