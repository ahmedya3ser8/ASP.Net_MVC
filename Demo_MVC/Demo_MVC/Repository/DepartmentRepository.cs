using Demo_MVC.Models;

namespace Demo_MVC.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		AppDbContext _context = new AppDbContext();
		public List<Department> GetAll()
		{
			return _context.Departments.ToList();
		}
		public Department GetById(int id)
		{
			return _context.Departments.FirstOrDefault(e => e.Id == id);
		}
		public void Insert(Department newDepartment)
		{
			_context.Departments.Add(newDepartment);
			_context.SaveChanges();
		}
		public void Update(int id, Department newDepartment)
		{
			Department oldEmployee = GetById(id);
			oldEmployee.Name = newDepartment.Name;
			oldEmployee.ManagerName = newDepartment.ManagerName;
			_context.Departments.Update(newDepartment);
			_context.SaveChanges();
		}
		public void Delete(int id)
		{
			Department department = GetById(id);
			_context.Departments.Remove(department);
			_context.SaveChanges();
		}
	}
}
