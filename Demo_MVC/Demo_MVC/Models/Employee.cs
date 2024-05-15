using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_MVC.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Address { get; set; }
		public string Image { get; set; }

		//[ForeignKey("Department")]
		public int Dept_Id { get; set; }
		public virtual Department? Department { get; set; }
	}
}
