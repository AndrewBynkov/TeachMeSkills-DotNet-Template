﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TeachMeSkills.Common.Interfaces
{
    /// <summary>
    /// Account manager.
    /// </summary>
    public interface IAccountManger
    {
        /// <summary>
        /// Sign up.
        /// </summary>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <returns>Identity result.</returns>
        Task<IdentityResult> SignUpAsync(string email, string userName, string password);
    }
}
