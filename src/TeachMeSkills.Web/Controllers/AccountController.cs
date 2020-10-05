using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeachMeSkills.Common.Interfaces;
using TeachMeSkills.DataAccessLayer.Entities;
using TeachMeSkills.Web.ViewModels;

namespace TeachMeSkills.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManger _accountManger;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IAccountManger accountManger,
                                 SignInManager<User> signInManager)
        {
            _accountManger = accountManger ?? throw new ArgumentNullException(nameof(accountManger));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: refactor it
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Username,
                };

                var result = await _accountManger.RegisterAsync(model.Email, model.Username, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
