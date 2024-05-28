namespace Demo_MVC.ViewModel
{
	public class EmployeeViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string Address { get; set; }
		public string Image { get; set; }
		public int Dept_Id { get; set; }
		public List<DepartmentViewModel> Departments { get; set; }
	}
}
