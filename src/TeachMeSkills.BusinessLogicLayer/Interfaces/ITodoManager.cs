using System.Collections.Generic;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Models;

namespace TeachMeSkills.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Manager Todo.
    /// </summary>
    public interface ITodoManager
    {
        /// <summary>
        /// Create todo by user identifier.
        /// </summary>
        /// <param name="todoDto">Todo data transfer object.</param>
        Task CreateAsync(TodoDto todoDto);

        /// <summary>
        /// Get todo by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <returns>Todo data transfer objects.</returns>
        Task<TodoDto> GetTodoAsync(int id, string userId);

        /// <summary>
        /// Get todo by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>List of Todo data transfer objects.</returns>
        Task<IEnumerable<TodoDto>> GetTodosAsync(string userId);

        /// <summary>
        /// Delete todo by identifier.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        Task DeleteAsync(int id, string userId);

        /// <summary>
        /// Change todo status.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        Task ChangeTodoStatusAsync(int id, string userId);

        /// <summary>
        /// Update todo by identifier.
        /// </summary>
        /// <param name="todoDto">Todo data transfer object.</param>
        Task UpdateAsync(TodoDto todoDto);
    }
}
