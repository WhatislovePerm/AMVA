using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Alcotripnics.Models;
using Microsoft.AspNetCore.Authorization;
using Alcotripnics.Data.Entity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alcotripnics.WebApp.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly ILogger<Account> _logger;

        private readonly UserManager<Account> _userManager;

        private readonly SignInManager<Account> _signInManager;

        public AccountController(
            ILogger<Account> logger,
            UserManager<Account> userManager,
            SignInManager<Account> signInManager
            )
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        // GET: /<controller>/
        [HttpGet, Route("Login"), AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }

        [HttpGet, Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = new Account() { Login = model.Login, UserName = model.Login, Password = model.Password };
                var registartionResult = await _userManager.CreateAsync(account, model.Password);

                if(registartionResult.Succeeded)
                {
                    await _signInManager.SignInAsync(account, true);
                    RedirectToAction("Home", "Index");
                }
                else
                {
                    foreach(var error in registartionResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult>LeaderList()
        {
            var leaderList = new List<LeaderListViewModel>();
            await _userManager.Users
                .ForEachAsync(x => leaderList.Add
                    (
                        new LeaderListViewModel()
                        {
                            Login = x.Login,
                            MoneyAmount = x.MoneyAmount
                        }
                    )
                );

            return View(leaderList);
        }


        [HttpPost, Route("Login"), AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel account)
        {

            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(account.Login, account.Password, account.RememberMe, false);

                if (loginResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(account.ReturnUrl) && Url.IsLocalUrl(account.ReturnUrl))
                    {
                        return Redirect(account.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин или пароль");
            }
            return View();
        }

        [HttpPost, Route("Logout")]
        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
     }
    
}

