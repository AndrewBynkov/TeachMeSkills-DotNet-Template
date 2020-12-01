using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TeachMeSkills.DataAccessLayer.Entities
{
    /// <summary>
    /// User by IdentityUser.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Navigation to Todos.
        /// </summary>
        public ICollection<Todo> Todos { get; set; }
    }
}
