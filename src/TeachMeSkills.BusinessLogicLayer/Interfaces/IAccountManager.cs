using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Models;

namespace TeachMeSkills.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Account manager.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Sign up.
        /// </summary>
        /// <param name="userDto">User data transfer object.</param>
        /// <returns>Identity result.</returns>
        Task<IdentityResult> SignUpAsync(UserDto userDto);

        /// <summary>
        /// Get user identifier by name.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <returns>Identifier (GUID).</returns>
        Task<string> GetUserIdByNameAsync(string name);
    }
}
