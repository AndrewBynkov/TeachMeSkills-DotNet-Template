using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.Common.Extensions;
using TeachMeSkills.Web.ViewModels;

namespace TeachMeSkills.Web.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly ITodoManager _todoManager;

        public TodoController(IAccountManager accountManager,
                              ITodoManager todoManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _todoManager = todoManager ?? throw new ArgumentNullException(nameof(todoManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var todoDtos = await _todoManager.GetTodosByUserIdAsync(userId);

            var todoViewModels = new List<TodoViewModel>();
            foreach (var todoDto in todoDtos)
            {
                todoViewModels.Add(new TodoViewModel
                {
                    Id = todoDto.Id,
                    Title = todoDto.Title,
                    Description = todoDto.Description,
                    Priority = todoDto.PriorityType.ToLocal(),
                    IsActive = todoDto.IsActive,
                    Created = todoDto.Created,
                    Closed = todoDto.Closed
                });
            }

            return View(todoViewModels);
        }
    }
}
