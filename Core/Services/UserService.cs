using Domain.Exceptions;
using Domain.Models;
using Domain.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using Services.Abstractions;
using Shared.UserDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Services
{
    public class UserService(IConfiguration _configuration , IUnitOfWork _unitOfWork) : IUserService
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = _unitOfWork.UserRepository.Get(U => U.Username == loginDto.Username).Result.FirstOrDefault()
                ?? throw new UserNotFoundException($"User {loginDto.Username} Not Found");
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new Exception("Invalid or password.");

            return new UserDto
            {
                Username = user.Username,
                Role = user.Role,
                Token = CreateToken(user)
            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var userExisit = await _unitOfWork.UserRepository.Get(U => U.Username == registerDto.Username).Result.AnyAsync();
            if (userExisit) throw new Exception($"User {registerDto.Username} Already Exisits");
            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Role = registerDto.Role,
            };
            await _unitOfWork.UserRepository.CreateAsync(user);
            var rows = await _unitOfWork.SaveChangesAsync();
            if (rows < 0) throw new Exception("Register Failed");
            return new UserDto
            {
                Username = user.Username,
                Role = user.Role,
                Token = CreateToken(user)
            };
        }

        private string CreateToken(User user)
        {
            // Private Claims
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.Username),
                new Claim(ClaimTypes.Role , user.Role)
            };

            //var roles = await _userManager.GetRolesAsync(user);
            //foreach (var role in roles)
            //    Claims.Add(new Claim(ClaimTypes.Role, role));

            //Security Key And Algorithm
            var secretKey = _configuration.GetSection("JWTOptions")["SecretKey"];

            //Convert the secretKey from string to bytes to be a Security Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //Credintials => Security Key & Algorithm
            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Create the JWT Token
            var token = new JwtSecurityToken(issuer: _configuration["JWTOptions:Issuer"],
                                             audience: _configuration["JWTOptions:Audience"],
                                             claims: Claims,
                                             expires: DateTime.Now.AddHours(1),
                                             signingCredentials: credintials);

            //Return the JWT Token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
