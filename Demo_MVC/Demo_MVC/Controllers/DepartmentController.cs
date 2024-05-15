using Demo_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
	public class DepartmentController : Controller
	{
		AppDbContext dbContext = new AppDbContext();
		public IActionResult Index()
		{
			List<Department> departments = dbContext.Departments.ToList();

			return View("Index", departments); // View --> "Index"  Model --> List<Department>
			// return View(departments); View --> not found  Model --> List<Department>
			// return View(); View --> not found  Model --> null
			// return View("Index"); View --> "Index"  Model --> null
		}
	}
}
