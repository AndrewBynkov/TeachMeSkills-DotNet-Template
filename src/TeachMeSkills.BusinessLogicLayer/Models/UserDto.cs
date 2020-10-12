namespace TeachMeSkills.BusinessLogicLayer.Models
{
    /// <summary>
    /// User data transfer object.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}
