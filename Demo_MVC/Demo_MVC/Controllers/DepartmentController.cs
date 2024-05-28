using Demo_MVC.Models;
using Demo_MVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
	public class DepartmentController : Controller
	{
		IEmployeeRepository employeeRepository = new EmployeeRepository();
		IDepartmentRepository departmentRepository = new DepartmentRepository();

		[HttpGet]
		public IActionResult Index()
		{
			List<Department> departments = departmentRepository.GetAll();

			return View("Index", departments); // View --> "Index"  Model --> List<Department>
			// return View(departments); View --> not found  Model --> List<Department>
			// return View(); View --> not found  Model --> null
			// return View("Index"); View --> "Index"  Model --> null
		}

		[HttpGet]
		public IActionResult New()
		{
			return View(new Department());
		}

		[HttpPost]
		public IActionResult SaveNew(Department dept)
		{
			if (dept.Name != null)
			{
				departmentRepository.Insert(dept);
				return RedirectToAction("Index");
			}

			return View("New", dept);
		}

		[HttpGet]
		public IActionResult ShowDepartmentEmployee()
		{
			List<Department> deptList = departmentRepository.GetAll();
			return View(deptList);
		}

		[HttpGet]
		public IActionResult GetEmployeePerDepartment(int deptId)
		{
			List<Employee> emps = employeeRepository.GetByDeptId(deptId);
			return Json(emps);
		}

		[HttpGet]
		[Route("show/{msg:alpha}")] // only way to call this action --> show/ayhaga
		public IActionResult ShowMsg(string msg)
		{
			return Content(msg);
		}
	}
}
