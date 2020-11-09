using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Models;
using TeachMeSkills.Common.Enums;
using TeachMeSkills.Common.Extensions;
using TeachMeSkills.Web.Models;
using TeachMeSkills.Web.ViewModels;

namespace TeachMeSkills.Web.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly ITodoManager _todoManager;

        public TodoController(
            IAccountManager accountManager,
            ITodoManager todoManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _todoManager = todoManager ?? throw new ArgumentNullException(nameof(todoManager));
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var todoDtos = await _todoManager.GetTodosAsync(userId);

            var todoViewModels = new List<TodoViewModel>();
            foreach (var todoDto in todoDtos)
            {
                todoViewModels.Add(new TodoViewModel
                {
                    Id = todoDto.Id,
                    Title = todoDto.Title,
                    Description = todoDto.Description,
                    Priority = todoDto.PriorityType.ValidatePriorityType(),
                    IsActive = todoDto.IsActive,
                    Created = todoDto.Created,
                    Closed = todoDto.Closed
                });
            }

            return View(todoViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GeneratePriorityTypeList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoActionViewModel model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var todoDto = new TodoDto
                {
                    UserId = userId,
                    Title = model.Title,
                    Description = model.Description,
                    PriorityType = PriorityTypeExtension.ToPriorityType(model.Priority)
                };

                await _todoManager.CreateAsync(todoDto);

                return RedirectToAction("Index", "Todo");
            }

            GeneratePriorityTypeList();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var todoDto = await _todoManager.GetTodoAsync(id, userId);

            var todoViewModel = new TodoViewModel
            {
                Id = todoDto.Id,
                Title = todoDto.Title,
                Description = todoDto.Description,
                Priority = todoDto.PriorityType.ToLocal(),
                IsActive = todoDto.IsActive,
                Created = todoDto.Created,
                Closed = todoDto.Closed
            };

            return View(todoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            var todoDto = await _todoManager.GetTodoAsync(id, userId);

            var todoActionViewModel = new TodoActionViewModel
            {
                Id = todoDto.Id,
                Title = todoDto.Title,
                Description = todoDto.Description,
                Priority = (int)todoDto.PriorityType,
            };

            GeneratePriorityTypeList();
            return View(todoActionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoActionViewModel model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
                var todoDto = new TodoDto
                {
                    Id = model.Id,
                    UserId = userId,
                    Title = model.Title,
                    Description = model.Description,
                    PriorityType = PriorityTypeExtension.ToPriorityType(model.Priority)
                };

                await _todoManager.UpdateAsync(todoDto);

                return RedirectToAction("Index", "Todo");
            }

            GeneratePriorityTypeList();
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _todoManager.DeleteAsync(id, userId);

            return RedirectToAction("Index", "Todo");
        }

        public async Task<IActionResult> Complete(int id)
        {
            var userId = await _accountManager.GetUserIdByNameAsync(User.Identity.Name);
            await _todoManager.ChangeTodoStatusAsync(id, userId);

            return RedirectToAction("Index", "Todo");
        }

        [NonAction]
        private void GeneratePriorityTypeList()
        {
            IEnumerable<PriorityTypeModel> priorityTypes = new List<PriorityTypeModel>
            {
                new PriorityTypeModel { Id = (int)PriorityType.Low, Type = PriorityType.Low.ToLocal() },
                new PriorityTypeModel { Id = (int)PriorityType.Medium, Type = PriorityType.Medium.ToLocal() },
                new PriorityTypeModel { Id = (int)PriorityType.High, Type = PriorityType.High.ToLocal() }
            };

            ViewBag.PriorityTypes = new SelectList(priorityTypes, "Id", "Type");
        }
    }
}
