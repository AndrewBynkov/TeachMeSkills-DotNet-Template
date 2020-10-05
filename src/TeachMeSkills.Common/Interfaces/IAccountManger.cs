using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TeachMeSkills.Common.Interfaces
{
    /// <summary>
    /// Account manager.
    /// </summary>
    public interface IAccountManger
    {
        /// <summary>
        /// Registration.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>Identity result.</returns>
        Task<IdentityResult> RegisterAsync(string email, string userName, string password);
    }
}
