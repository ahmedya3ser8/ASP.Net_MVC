using System.ComponentModel.DataAnnotations;

namespace Demo_MVC.Models
{
	public class UniqueNameAttribute: ValidationAttribute
	{
		private readonly AppDbContext dbContext;

		public UniqueNameAttribute(AppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			// return base.IsValid(value, validationContext);
			string name = value.ToString();
			//AppDbContext dbContext = new AppDbContext();
			Employee emp = dbContext.Employees.FirstOrDefault(e => e.Name == name);
			if (value != null)
			{
				if (emp == null)
				{
					return ValidationResult.Success;
				}
				return new ValidationResult("Name Already Found");
			}
			return new ValidationResult("Name Required");
		}
	}
}
