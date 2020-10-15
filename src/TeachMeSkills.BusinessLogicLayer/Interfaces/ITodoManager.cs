using System.Collections.Generic;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Models;

namespace TeachMeSkills.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Todo manager.
    /// </summary>
    public interface ITodoManager
    {
        /// <summary>
        /// Create todo by user identifier.
        /// </summary>
        /// <param name="todoDto">Todo data transfer object.</param>
        Task CreateAsync(TodoDto todoDto);

        /// <summary>
        /// Get todo by user identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>List of Todo data transfer objects.</returns>
        Task<IEnumerable<TodoDto>> GetTodosByUserIdAsync(string userId);

        /// <summary>
        /// Change todo status.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="id">Identifier.</param>
        Task ChangeTodoStatusAsync(string userId, int id);
    }
}
