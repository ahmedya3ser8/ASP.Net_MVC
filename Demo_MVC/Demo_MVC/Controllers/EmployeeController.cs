using Demo_MVC.Models;
using Demo_MVC.Repository;
using Demo_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
	public class EmployeeController : Controller
	{
		IEmployeeRepository employeeRepository = new EmployeeRepository();
		IDepartmentRepository departmentRepository = new DepartmentRepository();

		[HttpGet]
		public IActionResult Index()
		{
			return View(employeeRepository.GetAll());
		}

		[HttpGet]
		public IActionResult New()
		{
			ViewBag.deptList = departmentRepository.GetAll();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken] // call internal only
		public IActionResult SaveNew(Employee newEmp)
		{
			if (ModelState.IsValid)
			{
				employeeRepository.Insert(newEmp);
				return RedirectToAction("Index");
			}

			ViewBag.deptList = departmentRepository.GetAll();
			return View("New", newEmp);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Employee empModel = employeeRepository.GetById(id);
			ViewBag.deptList = departmentRepository.GetAll();
			return View(empModel);
		}

		[HttpPost]
		public IActionResult SaveEdit(int id, Employee newEmp)
		{
			if(ModelState.IsValid)
			{
				Employee oldEmp = employeeRepository.GetById(id);
				if (oldEmp != null)
				{
					employeeRepository.Update(id, newEmp);
					return RedirectToAction("Index");
				}
			}
			ViewBag.deptList = departmentRepository.GetAll();
			return View("Edit", newEmp);
		}

		public IActionResult CheckSalary(decimal Price)
		{
			if (Price > 2000)
			{
				return Json(true);
			}
			return Json(false);
		}

		public IActionResult Details(int id)
		{
			return View(employeeRepository.GetById(id));
		}

		public IActionResult DetailsUsingPartial(int id)
		{
			Employee emp = employeeRepository.GetById(id);
			return PartialView("_EmployeeCardPartial", emp);
		}
	}
}
