using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TeachMeSkills.BusinessLogicLayer.Interfaces;
using TeachMeSkills.BusinessLogicLayer.Models;
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

        public async Task<IdentityResult> SignUpAsync(UserDto userDto)
        {
            var user = new User
            {
                Email = userDto.Email,
                UserName = userDto.Username,
            };

            return await _userManager.CreateAsync(user, userDto.Password);
        }

        public async Task<string> GetUserIdByNameAsync(string name)
        {
            var user = await _userManager.Users.FirstAsync(u => u.UserName == name);
            return user.Id;
        }
    }
}
