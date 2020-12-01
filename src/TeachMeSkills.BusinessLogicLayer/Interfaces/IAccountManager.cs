using System.Threading.Tasks;

namespace TeachMeSkills.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Account manager.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Get user identifier by name.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <returns>Identifier (GUID).</returns>
        Task<string> GetUserIdByNameAsync(string name);
    }
}
