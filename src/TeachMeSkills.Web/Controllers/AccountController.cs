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

                var result = await _accountManger.SignUpAsync(model.Email, model.Username, model.Password);
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

        [HttpGet]
        public IActionResult SignIn(string returnUrl = null)
        {
            var signInViewModel = new SignInViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(signInViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Incorrect email and (or) password");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
