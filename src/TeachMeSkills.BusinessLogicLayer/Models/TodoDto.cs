using System;
using TeachMeSkills.Common.Enums;

namespace TeachMeSkills.BusinessLogicLayer.Models
{
    /// <summary>
    /// Data transfer object (Todo).
    /// </summary>
    public class TodoDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public string UserId { get; set; }

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
        public PriorityType PriorityType { get; set; }

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
