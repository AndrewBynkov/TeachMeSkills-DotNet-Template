using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.WebApi.Contracts.Responses;
using TeachMeSkills.WebApi.Extensions;

namespace TeachMeSkills.WebApi.Controllers
{
    // TODO: update global handler

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoManager _todoManager;

        public TodoController(ITodoManager todoManager)
        {
            _todoManager = todoManager ?? throw new ArgumentNullException(nameof(todoManager));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var userId = HttpContext.GetUserId();

            // TODO: check userId for null

            return Ok(new TodoAllResponse
            {
                Todos = await _todoManager.GetTodosAsync(userId)
            });
        }
    }
}
