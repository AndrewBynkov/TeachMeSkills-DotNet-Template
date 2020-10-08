using System;

namespace TeachMeSkills.BusinessLogicLayer.Models
{
    /// <summary>
    ///  Todo data transfer object.
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
