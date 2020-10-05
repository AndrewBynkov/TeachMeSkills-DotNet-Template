using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using TeachMeSkills.Common.Interfaces;
using TeachMeSkills.DataAccessLayer.Entities;

namespace TeachMeSkills.BusinessLogicLayer.Managers
{
    /// <inheritdoc cref="IAccountManger"/>
    public class AccountManger : IAccountManger
    {
        private readonly UserManager<User> _userManager;

        public AccountManger(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IdentityResult> SignUpAsync(string email, string userName, string password)
        {
            var user = new User 
            { 
                Email = email,
                UserName = userName,
            };

            return await _userManager.CreateAsync(user, password);
        }
    }
}
