using System;

namespace TeachMeSkills.WebApi.Helpers
{
    /// <summary>
    /// JWT settings.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Secret key.
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Lifetime.
        /// </summary>
        public TimeSpan Lifetime { get; set; }

        /// <summary>
        /// Issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Audience.
        /// </summary>
        public string Audience { get; set; }
    }
}
