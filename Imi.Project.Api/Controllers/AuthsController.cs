using Imi.Project.Api.Core.Dtos.Request;
using Imi.Project.Api.Core.Dtos.Response;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthsController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto registration)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ApplicationUser newUser = new ApplicationUser
            {
                UserName = registration.Username,
                Email = registration.Email
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddClaimAsync(newUser, new Claim("HasApprovedTermsAndConditions",newUser.TermsAndConditions.ToString()));
            await _userManager.AddToRoleAsync(newUser, "User");
           
            newUser = await _userManager.FindByEmailAsync(registration.Email);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequestDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var applicationUser = await _userManager.FindByEmailAsync(login.Email);
            IList<string> roles = await _userManager.GetRolesAsync(applicationUser);

            JwtSecurityToken token = await GenerateTokenAsync(applicationUser);

            string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new LoginUserResponseDto()
            {
                Token = serializedToken,
                Roles = roles.ToArray()
            });
        }

        private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>();

            var userClaims = await _userManager.GetClaimsAsync(user);

            claims.AddRange(userClaims);

            var roleClaims = await _userManager.GetRolesAsync(user);
            foreach (var roleClaim in roleClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleClaim));
                claims.Add(new Claim("TermsAndConditions", "true"));
            }

            var expirationDays = _configuration.GetValue<int>("JWTConfiguration:TokenExpirationDays");
            var siginingKey = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWTConfiguration:SigningKey"));
            var token = new JwtSecurityToken
            (
                issuer: _configuration.GetValue<string>("JWTConfiguration:Issuer"),
                audience: _configuration.GetValue<string>("JWTConfiguration:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(siginingKey), SecurityAlgorithms.HmacSha256)
            ); ;

            return token;
        }
    }
}
