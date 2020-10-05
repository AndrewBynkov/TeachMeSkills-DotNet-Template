using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TeachMeSkills.DataAccessLayer.Configurations;
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

        /// <summary>
        /// Todos.
        /// </summary>
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new TodoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
