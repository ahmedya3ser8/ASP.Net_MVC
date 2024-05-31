using Demo_MVC.Models;
using Demo_MVC.ViewModel;
using Demo_MVC.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo_MVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser userModel = new ApplicationUser();
				userModel.UserName = newUserVM.UserName;
				userModel.Address = newUserVM.Address;
				userModel.PasswordHash = newUserVM.Password;
				IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(userModel, "User"); // default role to any user
					// create cookie
					/*
					* List<Claim> claims = new List<Claim>();
					* claims.Add(new Claim("color", "red"));
					* await signInManager.SignInWithClaimsAsync(userModel, false, claims);
					*/
					await signInManager.SignInAsync(userModel,false);
					return RedirectToAction("Index", "Employee");
				}
				else
				{
					foreach(var errorItem in result.Errors)
					{
						ModelState.AddModelError("Password", errorItem.Description);
					}
				}
			}
			return View(newUserVM);
		}

		public IActionResult Logout()
		{
			signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser userModel = await userManager.FindByNameAsync(userViewModel.UserName);
				if (userModel != null)
				{
					bool found = await userManager.CheckPasswordAsync(userModel, userViewModel.Password);
					if (found)
					{
						await signInManager.SignInAsync(userModel, userViewModel.RememberMe);
						return RedirectToAction("Index", "Employee");
					}
				}
				ModelState.AddModelError("", "UserName or Password are wrong");

			}
			return View(userViewModel);
		}

		[HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmin()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
		{
			if (ModelState.IsValid)
			{
				ApplicationUser userModel = new ApplicationUser();
				userModel.UserName = newUserVM.UserName;
				userModel.Address = newUserVM.Address;
				userModel.PasswordHash = newUserVM.Password;
				IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(userModel, "Admin"); // default role to any user
					// create cookie
					await signInManager.SignInAsync(userModel, false);
					return RedirectToAction("Index", "Employee");
				}
				else
				{
					foreach (var errorItem in result.Errors)
					{
						ModelState.AddModelError("Password", errorItem.Description);
					}
				}
			}
            return View(newUserVM);
		}
	}
}
