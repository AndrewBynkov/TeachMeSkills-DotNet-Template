using System;

namespace TeachMeSkills.Web.ViewModels
{
    /// <summary>
    /// List view model.
    /// </summary>
    public class TodoViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

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
        public string Priority { get; set; }

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
