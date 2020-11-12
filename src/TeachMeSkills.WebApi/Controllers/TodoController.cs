using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Models;
using TeachMeSkills.WebApi.Contracts.Requests;
using TeachMeSkills.WebApi.Contracts.Responses;
using TeachMeSkills.WebApi.Extensions;

namespace TeachMeSkills.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoManager _todoManager;
        private readonly IAccountManager _accountManager;

        public TodoController(
            ITodoManager todoManager,
            IAccountManager accountManager)
        {
            _todoManager = todoManager ?? throw new ArgumentNullException(nameof(todoManager));
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _todoManager.GetTodosAsync(await GetUserIdAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _todoManager.GetTodoAsync(id, await GetUserIdAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TodoActionRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {
                var todoDto = new TodoDto
                {
                    UserId = await GetUserIdAsync(),
                    Title = request.Title,
                    Description = request.Description,
                    PriorityType = request.PriorityType,
                };

                await _todoManager.CreateAsync(todoDto);

                return Ok(); // Created
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TodoActionRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {
                var todoDto = new TodoDto
                {
                    Id = id,
                    UserId = await GetUserIdAsync(),
                    Title = request.Title,
                    Description = request.Description,
                    PriorityType = request.PriorityType,
                };

                await _todoManager.UpdateAsync(todoDto);

                return NoContent();
            }

            return Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _todoManager.DeleteAsync(id, await GetUserIdAsync());
            return NoContent();
        }

        [HttpGet("complete/{id}")]
        public async Task<IActionResult> CompleteAsync(int id)
        {
            await _todoManager.ChangeTodoStatusAsync(id, await GetUserIdAsync());
            return Ok();
        }

        private async Task<string> GetUserIdAsync() =>
            await _accountManager.GetUserIdByNameAsync(HttpContext.GetUserName());
    }
}
