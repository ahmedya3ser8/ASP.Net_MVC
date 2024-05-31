using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_MVC.Models
{
	public class AppDbContext: IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions options): base(options)
        {
        }

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseResult> CourseResults { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
