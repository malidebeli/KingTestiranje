
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models.Identity;
using TicketOffice.Core.Services.Identity;
using TicketOffice.Services.Configuration;

namespace TicketOffice.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtConfiguration _jwtSettings;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public AuthService(IOptions<JwtConfiguration> jwtSettings, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public AppUser GetUserById(Guid userId)
        {           
            return _userManager.Users.SingleOrDefault(u => u.Id == userId);
        }
        public AppUser GetUserByUsername(string username)
        {
            return _userManager.Users.SingleOrDefault(u => u.UserName == username);
        }

        public async Task<string> Login(AppUser user)
        {            
            var usr = _userManager.Users.SingleOrDefault(u => u.UserName == user.UserName);
            if (user == null)
            {
                throw new Exception($"User with {user.UserName} not found.");
            }

            await _signInManager.SignInAsync(usr, false);
            JwtSecurityToken jwtSecurityToken = await GenerateToken(usr);
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private async Task<JwtSecurityToken> GenerateToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
