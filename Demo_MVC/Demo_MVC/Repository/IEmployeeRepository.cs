using Demo_MVC.Models;

namespace Demo_MVC.Repository
{
	public interface IEmployeeRepository
	{
		void Delete(int id);
		List<Employee> GetAll();
		List<Employee> GetByDeptId(int deptId);
		Employee GetById(int id);
		void Insert(Employee newEmployee);
		void Update(int id, Employee newEmployee);
	}
}