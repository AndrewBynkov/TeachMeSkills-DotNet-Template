using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.BusinessLogicLayer.Managers
{
    /// <inheritdoc cref="IAccountManager"/>
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;

        public AccountManager(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<string> GetUserIdByNameAsync(string name)
        {
            var user = await _userManager.Users.FirstAsync(u => u.UserName == name);
            if (user is null)
            {
                throw new KeyNotFoundException(""); // TODO: literal
            }

            return user.Id;
        }
    }
}
