using System.ComponentModel.DataAnnotations;

namespace TeachMeSkills.WebApi.Contracts.Requests
{
    /// <summary>
    /// Register request.
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Password confirm.
        /// </summary>
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords are different")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
