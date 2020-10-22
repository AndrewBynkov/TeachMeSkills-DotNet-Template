using System.ComponentModel.DataAnnotations;
using TeachMeSkills.Common.Constants;

namespace TeachMeSkills.Web.ViewModels
{
    /// <summary>
    /// Todo action ViewModel.
    /// </summary>
    public class TodoActionViewModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [Required]
        [StringLength(ConfigurationContants.SqlMaxLengthMedium, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [Required]
        [StringLength(ConfigurationContants.SqlMaxLengthLong, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 10)]
        public string Description { get; set; }

        /// <summary>
        /// Priority.
        /// </summary>
        [Required]
        public int Priority { get; set; }
    }
}
