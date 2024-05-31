﻿using Demo_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo_MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = roleViewModel.RoleName;
                IdentityResult result = await roleManager.CreateAsync(roleModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("", errorItem.Description);
                    }
                }
            }
            return View(roleViewModel);
        }
    }
}
