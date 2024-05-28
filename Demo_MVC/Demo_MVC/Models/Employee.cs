using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_MVC.Models
{
	public class Employee
	{
		public int Id { get; set; }
		// [Required]
		[MinLength(3)]
		[MaxLength(50)]
		// Validation Attribute --> Server Side Only [UniqueName]
		// [UniqueName]
		public string Name { get; set; }
		[RegularExpression(@"[0-9]{4}", ErrorMessage = "Filed must be in Range between 2000 and 6000")]
		[Range(2000,6000)]
		[Remote("CheckSalary", "Employee", ErrorMessage = "Salary Must be Greater Than 2000")]
		public decimal Price { get; set; }
		[RegularExpression(@"(Alex|Cairo|Quena)", ErrorMessage = "Filed must be Alex Or Cairo Or Quena")]
		public string Address { get; set; }
		[RegularExpression(@"[a-z]+\.(jpg|png)", ErrorMessage = "Filed must be char with jpg Or png")]
		public string Image { get; set; }
		//[ForeignKey("Department")]
		[Display(Name = "Department")]
		public int? Dept_Id { get; set; }
		public virtual Department? Department { get; set; }
	}
}
