using Demo_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
	public class DepartmentController : Controller
	{
		AppDbContext dbContext = new AppDbContext();

		[HttpGet]
		public IActionResult Index()
		{
			List<Department> departments = dbContext.Departments.ToList();

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
				dbContext.Departments.Add(dept);
				dbContext.SaveChanges();
				return RedirectToAction("Index");
			}

			return View("New", dept);
		}
	}
}
