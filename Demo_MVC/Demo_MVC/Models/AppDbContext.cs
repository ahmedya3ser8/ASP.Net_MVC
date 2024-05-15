using Microsoft.EntityFrameworkCore;

namespace Demo_MVC.Models
{
	public class AppDbContext: DbContext
	{
        public AppDbContext(): base()
        {
        }
        public AppDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = Demo_MVC; Integrated Security = True; TrustServerCertificate = True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
