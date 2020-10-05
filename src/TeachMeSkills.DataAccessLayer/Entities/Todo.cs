using System;
using TeachMeSkills.Common.Interfaces;

namespace TeachMeSkills.DataAccessLayer.Entities
{
    /// <summary>
    /// Todo.
    /// </summary>
    public class Todo : IHasDbIdentity, IHasUserIdentity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string UserId { get; set; }

        /// <summary>
        /// Navigation to User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Priority.
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// IsActive.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Closed.
        /// </summary>
        public DateTime? Closed { get; set; }
    }
}
