using Demo_MVC.Models;

namespace Demo_MVC.Repository
{
	public interface IDepartmentRepository
	{
		List<Department> GetAll();
		Department GetById(int id);
		void Insert(Department newDepartment);
		void Update(int id, Department newDepartment);
		void Delete(int id);
	}
}