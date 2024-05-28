using Demo_MVC.Models;

namespace Demo_MVC.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		AppDbContext _context = new AppDbContext();
		public List<Employee> GetAll()
		{
			return _context.Employees.ToList();
		}
		public Employee GetById(int id)
		{
			return _context.Employees.FirstOrDefault(e => e.Id == id);
		}
		public List<Employee> GetByDeptId(int deptId)
		{
			return _context.Employees.Where(e => e.Dept_Id == deptId).ToList();
		}
		public void Insert(Employee newEmployee)
		{
			_context.Employees.Add(newEmployee);
			_context.SaveChanges();
		}
		public void Update(int id, Employee newEmployee)
		{
			Employee oldEmployee = GetById(id);
			oldEmployee.Name = newEmployee.Name;
			oldEmployee.Price = newEmployee.Price;
			oldEmployee.Address = newEmployee.Address;
			oldEmployee.Image = newEmployee.Image;
			oldEmployee.Dept_Id = newEmployee.Dept_Id;
			_context.Employees.Update(newEmployee);
			_context.SaveChanges();
		}
		public void Delete(int id)
		{
			Employee employee = GetById(id);
			_context.Employees.Remove(employee);
			_context.SaveChanges();
		}
	}
}
