using Demo_MVC.Models;
using Demo_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
	public class PassDataController : Controller
	{
		// Pass Data From Action C# To View HTML
		/*
			* Model 
			* ViewData  --> not recommended
			* ViewBag   --> not recommended
			* ViewModel --> the best way
		*/
		AppDbContext dbContext = new AppDbContext();
		public IActionResult testViewData(int id)
		{
			Employee employeeModel = dbContext.Employees.FirstOrDefault(e => e.Id == id);

			string message = "hello";
			List<string> branches = new List<string>();
			branches.Add("Alex");
			branches.Add("Cairo");
			branches.Add("Sohag");
			branches.Add("Mansoura");
			branches.Add("Quena");

			int temp = 44;
			string color = "red";

			// Using ViewData
				//ViewData["Message"] = message;
				//ViewData["branches"] = branches;
				//ViewData["temp"] = temp;
				//ViewData["color"] = color;

			// Using ViewBag
				ViewBag.Message = message;
				ViewBag.branches = branches;
				ViewBag.temp = temp;
				ViewBag.color = color;

            // Model --> departmentsList
            // ViewData --> set action -- get view ---> Dictionary<string, object>

            return View(employeeModel);
		}

		public IActionResult testViewModel(int id)
		{
            Employee employeeModel = dbContext.Employees.FirstOrDefault(e => e.Id == id);

            string message = "hello";
            List<string> branches = new List<string>();
            branches.Add("Alex");
            branches.Add("Cairo");
            branches.Add("Sohag");
            branches.Add("Mansoura");
            branches.Add("Quena");

            int temp = 44;
            string color = "red";

            // Declare ViewModel
			EmployeeWithMessageAndBranchesViewModel empViewModel = new EmployeeWithMessageAndBranchesViewModel();
            
			// get data from model set view
			empViewModel.Message = message;
			empViewModel.Branches = branches;
			empViewModel.Temp = temp;
			empViewModel.Color = color;
			empViewModel.EmployeeName = employeeModel.Name;
			empViewModel.EmployeeId = employeeModel.Id;

            return View(empViewModel);
        }
    }
}
