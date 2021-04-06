using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using api.Entities;
using api.Exception;
using api.Middleware;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto loginDto);
    }

    public class AccountService : IAccountService
    {
        private readonly AuthenticationSettings _settings;
        private readonly LostDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(AuthenticationSettings settings,
            LostDbContext dbContext,
            IPasswordHasher<User> passwordHasher)
        {
            _settings = settings;
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                RoleId = dto.RoleId,
                Nationality = dto.Nationality,
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string GenerateJwt(LoginDto loginDto)
        {
            var user = _dbContext
                .Users
                .Include(u => u.Role)
                .FirstOrDefault(e => e.Email == loginDto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid Username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user,
                user.PasswordHash,
                loginDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid Username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role}"),
                new Claim("Nationality", $"{user.Nationality}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_settings.JwtExpireDays);

            var token = new JwtSecurityToken(_settings.JwtIssuer,
                _settings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}