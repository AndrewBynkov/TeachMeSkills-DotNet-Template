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
        /// Get todo by identifier.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>Todo.</returns>
        Task<IEnumerable<TodoDto>> GetTodosByUserIdAsync(string userId);
    }
}
