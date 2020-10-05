using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.DataAccessLayer.Contexts
{
    /// <summary>
    /// TeachMeSkills database context.
    /// </summary>
    public class TeachMeSkillsContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Contructor with params.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public TeachMeSkillsContext(DbContextOptions<TeachMeSkillsContext> options)
            : base(options)
        {
        }


    }
}
