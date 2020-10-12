using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Models;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.BusinessLogicLayer.Managers
{
    /// <inheritdoc cref="ITodoManager"/>
    public class TodoManager : ITodoManager
    {
        private readonly IRepository<Todo> _repositoryTodo;

        public TodoManager(IRepository<Todo> repositoryTodo)
        {
            _repositoryTodo = repositoryTodo ?? throw new ArgumentNullException(nameof(repositoryTodo));
        }

        public async Task<IEnumerable<TodoDto>> GetTodosByUserIdAsync(string userId)
        {
            var todoDtos = new List<TodoDto>();
            var todos = await _repositoryTodo
                .GetAll()
                .AsNoTracking()
                .Where(todo => todo.UserId == userId)
                .ToListAsync();

            if (!todos.Any())
            {
                return todoDtos;
            }

            foreach (var todo in todos)
            {
                todoDtos.Add(new TodoDto
                {
                    Id = todo.Id,
                    UserId = todo.UserId,
                    Title = todo.Title,
                    Description = todo.Description,
                    PriorityType = todo.PriorityType,
                    IsActive = todo.IsActive,
                    Created = todo.Created,
                    Closed = todo.Closed
                });
            }

            return todoDtos;
        }
    }
}
