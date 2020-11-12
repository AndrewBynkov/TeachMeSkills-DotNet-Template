using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachMeSkills.WebApi.Constants
{
    /// <summary>
    /// Swagger parameters.
    /// </summary>
    public static class SwaggerParameter
    {
        /// <summary>
        /// Version.
        /// </summary>
        public const string Version = "v1";

        /// <summary>
        /// Title.
        /// </summary>
        public const string Title = "API";

        /// <summary>
        /// Description.
        /// </summary>
        public const string Description = "TeachMeSkills ToDo API";

        /// <summary>
        /// Contact.
        /// </summary>
        public static class Contact
        {
            /// <summary>
            /// Name.
            /// </summary>
            public const string Name = "Mikhail M.";
        }

        /// <summary>
        /// Security.
        /// </summary>
        public static class Security
        {
            /// <summary>
            /// Description.
            /// </summary>
            public const string Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"";

            /// <summary>
            /// Name.
            /// </summary>
            public const string Name = "Authorization";

            /// <summary>
            /// Schema.
            /// </summary>
            public const string Schema = "Bearer";

            /// <summary>
            /// HTTP Authorization.
            /// </summary>
            public const string HttpAuth = "bearer";
        }
    }
}
