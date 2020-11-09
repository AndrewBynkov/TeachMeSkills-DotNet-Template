using System.ComponentModel.DataAnnotations;

namespace TeachMeSkills.WebApi.Contracts.Requests
{
    /// <summary>
    /// Login request.
    /// </summary>
    public class LoginRequest
    {
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
    }
}
