using System;
using TeachMeSkills.Common.Enums;

namespace TeachMeSkills.WebApi.Contracts.Requests
{
    /// <summary>
    /// Create or update request.
    /// </summary>
    public class TodoActionRequest
    {
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
        /// Created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}
