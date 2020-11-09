using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TeachMeSkills.WebApi.Extensions
{
    /// <summary>
    /// Extensions for JWT Token.
    /// </summary>
    public static class JwtTokenExtension
    {
        /// <summary>
        /// Get user identifier.
        /// </summary>
        /// <param name="httpContext">Application HttpContext.</param>
        /// <returns>Identifier.</returns>
        public static string GetUserId(this HttpContext httpContext)
        {
            httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));

            return httpContext.User is null
                ? string.Empty
                : httpContext.User.Claims
                    .SingleOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        }
    }
}
