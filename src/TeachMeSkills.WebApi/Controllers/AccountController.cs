using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Core;
using TeachMeSkills.Common.Resources;
using TeachMeSkills.DataAccessLayer.Entities;
using TeachMeSkills.WebApi.Contracts.Requests;
using TeachMeSkills.WebApi.Contracts.Responses;
using TeachMeSkills.WebApi.Helpers;

namespace TeachMeSkills.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // TODO: add some AccountResources

        private readonly IOptions<JwtSettings> _jwtOptions;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public AccountController(
            IOptions<JwtSettings> jwtOptions,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IEmailService emailService)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(new AuthResponse
                    {
                        IsSuccessful = true,
                        Token = await GenerateJwtToken(request.Username),
                    });
                }
            }

            return Unauthorized(new AuthResponse
            {
                Message = AccountResource.IncorrectData
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            request = request ?? throw new ArgumentNullException(nameof(request));

            var errorMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = request.Email,
                    UserName = request.Username,
                };

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    _emailService.Send(request.Email, EmailResource.Subject, EmailResource.Message);

                    return Ok(new AuthResponse
                    {
                        IsSuccessful = true,
                        Token = await GenerateJwtToken(request.Username),
                    });
                }

                errorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
            }

            return Unauthorized(new AuthResponse
            {
                Message = errorMessage
            });
        }

        private Task<string> GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.Now.Add(_jwtOptions.Value.Lifetime),
                signingCredentials: credentials
            );

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
