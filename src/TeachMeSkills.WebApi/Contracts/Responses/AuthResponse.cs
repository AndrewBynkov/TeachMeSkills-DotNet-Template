using System.Collections.Generic;

namespace TeachMeSkills.WebApi.Contracts.Responses
{
    /// <summary>
    /// Authentication response.
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Is successful.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Jwt token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Errors.
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}
