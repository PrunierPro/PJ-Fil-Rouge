using FilRougeApi.Helpers;
using FilRougeApi.Repositories;
using FilRougeCore.DTOs;
using FilRougeCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilRougeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly AppSettings _settings;
        private readonly string _securityKey = "la clé super secrète de la pokemon api";
        public AuthenticationController(IRepository<User> userRepository,
            IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _settings = appSettings.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _userRepository.Get(u => u.Email == user.Email) != null)
                return BadRequest("Email is already taken!");

            user.PassWord = PasswordCrypter.Encrypt(user.PassWord, _securityKey);
            // pour restreindre la création d'admins : isAdmin = false

            if (await _userRepository.Add(user) > 0)
                return Ok("User registered.");
            return BadRequest("Something went wrong...");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO login)
        {
            login.PassWord = PasswordCrypter.Encrypt(login.PassWord, _securityKey);

            var user = await _userRepository.Get(u => u.Email == login.Email && u.PassWord == login.PassWord);

            if (user == null) return BadRequest("Invalid Authentication !");

            var role = user.IsAdmin ? "Admin" : "User";

            //JWT
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            SigningCredentials signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_settings.SecretKey!)),
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(7)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                Token = token,
                Message = "Valid Authentication !",
                User = user
            });
        }

        // possible d'ajouter les actions de crud des users ici ou dans un controlleur UserController
    }
}
