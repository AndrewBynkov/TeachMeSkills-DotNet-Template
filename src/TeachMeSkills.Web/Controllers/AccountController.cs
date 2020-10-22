using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Models;
using TeachMeSkills.Common.Resources;
using TeachMeSkills.DataAccessLayer.Entities;
using TeachMeSkills.Web.ViewModels;

// TODO:

//share todo
// email sender

namespace TeachMeSkills.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManger;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IAccountManager accountManger,
                                 SignInManager<User> signInManager)
        {
            _accountManger = accountManger ?? throw new ArgumentNullException(nameof(accountManger));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [Authorize]
        public IActionResult Secret(int id, [FromQuery] string query, [FromBody] SecretViewModel secret, [FromHeader] string secretValue)
        {
            return Content($"Route: {id}, Query: {query}, Body: {secret.Key}, Header: {secretValue}");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password
                };

                var result = await _accountManger.SignUpAsync(userDto);
                if (result.Succeeded)
                {
                    var user = new User
                    {
                        Email = model.Email,
                        UserName = model.Username,
                    };

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
        public IActionResult Login(string returnUrl = null)
        {
            var signInViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(signInViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
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

                ModelState.AddModelError(string.Empty, AccountResource.IncorrectData);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
