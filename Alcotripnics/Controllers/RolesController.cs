using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alcotripnics.Data.Entity;
using Alcotripnics.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alcotripnics.WebApp.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {

        private RoleManager<IdentityRole> _roleManager;

        private UserManager<Account> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<Account> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public IActionResult Create() => View();

        // GET: /<controller>/
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                var creationResult = await _roleManager.CreateAsync(new IdentityRole(name));

                if (creationResult.Succeeded)
                   return RedirectToAction("Index");
                else
                {
                    foreach (var error in creationResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(name);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult AccountList() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Edit(string accountId)
        {
            Account account = await _userManager.FindByIdAsync(accountId);
            if (account != null)
            {
                var userRoles = await _userManager.GetRolesAsync(account);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    AccountId = account.Id,
                    AccountRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string accountId, List<string> roles)
        {
            Account account = await _userManager.FindByIdAsync(accountId);
            if (account != null)
            {
                var userRoles = await _userManager.GetRolesAsync(account);

                var allRoles = _roleManager.Roles.ToList();

                var addedRoles = roles.Except(userRoles);

                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(account, addedRoles);

                await _userManager.RemoveFromRolesAsync(account, removedRoles);

                return RedirectToAction("AccountList");
            }

            return NotFound();
        }
    }
}

