using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Models;
using TeachMeSkills.Common.Resources;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.BusinessLogicLayer.Managers
{
    /// <inheritdoc cref="ITodoManager"/>
    public class TodoManager : ITodoManager
    {
        private readonly IRepositoryManager<Todo> _repositoryTodo;

        public TodoManager(IRepositoryManager<Todo> repositoryTodo)
        {
            _repositoryTodo = repositoryTodo ?? throw new ArgumentNullException(nameof(repositoryTodo));
        }

        public async Task CreateAsync(TodoDto todoDto)
        {
            todoDto = todoDto ?? throw new ArgumentNullException(nameof(todoDto));

            var todo = new Todo
            {
                UserId = todoDto.UserId,
                Title = todoDto.Title,
                Description = todoDto.Description,
                PriorityType = todoDto.PriorityType,
                Completed = false,
                Created = DateTime.Now,
            };

            await _repositoryTodo.CreateAsync(todo);
            await _repositoryTodo.SaveChangesAsync();
        }

        public async Task<TodoDto> GetTodoAsync(int id, string userId)
        {
            var todo = await _repositoryTodo
                .GetEntityWithoutTrackingAsync(todo =>
                    todo.Id == id && todo.UserId == userId);

            if (todo is null)
            {
                throw new KeyNotFoundException(ErrorResource.TodoNotFound);
            }

            var todoDto = new TodoDto
            {
                Id = todo.Id,
                UserId = todo.UserId,
                Title = todo.Title,
                Description = todo.Description,
                PriorityType = todo.PriorityType,
                IsActive = todo.Completed,
                Created = todo.Created,
                Closed = todo.Closed
            };

            return todoDto;
        }

        public async Task<IEnumerable<TodoDto>> GetTodosAsync(string userId)
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
                    IsActive = todo.Completed,
                    Created = todo.Created,
                    Closed = todo.Closed
                });
            }

            return todoDtos;
        }

        public async Task UpdateAsync(TodoDto todoDto)
        {
            todoDto = todoDto ?? throw new ArgumentNullException(nameof(todoDto));

            var todo = await _repositoryTodo
                .GetEntityAsync(todo =>
                    todo.Id == todoDto.Id && todo.UserId == todoDto.UserId);

            if (todo is null)
            {
                throw new KeyNotFoundException(ErrorResource.TodoNotFound);
            }

            static bool CheckAndUpdate(Todo todo, TodoDto newTodo)
            {
                var toUpdate = false;

                if (todo.Title != newTodo.Title)
                {
                    todo.Title = newTodo.Title;
                    toUpdate = true;
                }

                if (todo.Description != newTodo.Description)
                {
                    todo.Description = newTodo.Description;
                    toUpdate = true;
                }

                if (todo.PriorityType != newTodo.PriorityType)
                {
                    todo.PriorityType = newTodo.PriorityType;
                    toUpdate = true;
                }

                return toUpdate;
            }

            if (CheckAndUpdate(todo, todoDto))
            {
                await _repositoryTodo.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var todo = await _repositoryTodo
                .GetEntityAsync(todo =>
                    todo.Id == id && todo.UserId == userId);

            if (todo is null)
            {
                throw new KeyNotFoundException(ErrorResource.TodoNotFound);
            }

            _repositoryTodo.Delete(todo);
            await _repositoryTodo.SaveChangesAsync();
        }

        public async Task ChangeTodoStatusAsync(int id, string userId)
        {
            var todo = await _repositoryTodo
                .GetEntityAsync(todo =>
                    todo.Id == id && todo.UserId == userId);

            if (todo is null)
            {
                throw new KeyNotFoundException(ErrorResource.TodoNotFound);
            }

            todo.Completed = true;
            todo.Closed = DateTime.Now;

            _repositoryTodo.Update(todo);
            await _repositoryTodo.SaveChangesAsync();
        }
    }
}
