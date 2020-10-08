using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

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
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>Identity result.</returns>
        Task<IdentityResult> SignUpAsync(string email, string userName, string password);

        /// <summary>
        /// Get user identifier by name.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <returns>Identifier (GUID).</returns>
        Task<string> GetUserIdByNameAsync(string name);
    }
}
