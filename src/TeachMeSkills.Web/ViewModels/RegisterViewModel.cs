using System.ComponentModel.DataAnnotations;

namespace TeachMeSkills.Web.ViewModels
{
    /// <summary>
    /// Register view model.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [Display(Name = nameof(Email))]
        public string Email { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        [Required]
        [Display(Name = nameof(Username))]
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Password))]
        public string Password { get; set; }

        /// <summary>
        /// Password confirm.
        /// </summary>
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password")]
        public string PasswordConfirm { get; set; }
    }
}
