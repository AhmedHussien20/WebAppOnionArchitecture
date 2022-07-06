using BusinessLayer.DTOs;
using DomainLayer.Models.Auth;
using InfrastructureLayer.RespositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessLayer.IServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BusinessLayer.Services
{
    public class AuthService: IAuthService
    {
        #region Property
        private IRepository<Users> _repository;
        private readonly IConfiguration _config;
        #endregion

        #region Constructor
        public AuthService(IRepository<Users> repository,IConfiguration config)
        {
            _repository=repository;
            _config=config;
        }
        #endregion

        public async Task<LoginResponse>  Login(LoginDTO loginDTO)
        {
            //To Do Encrept and decrept the Password in the regist Method
            Users users = await _repository.GetAll().FirstOrDefaultAsync(x => x.UserName == loginDTO.userName && x.Password == loginDTO.password);
            if(users == null)
            {
                throw new Exception("Invalid userName or Password");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.UserName.ToString()),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(int.Parse(_config["AppSettings:ExpirationTimeInMinutes"])).ToString())
                }),
                Expires = DateTime.Now.AddMinutes(int.Parse(_config["AppSettings:ExpirationTimeInMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponse loginResponse = new LoginResponse();
            loginResponse.AccessToken = tokenHandler.WriteToken(token);
            return loginResponse;
        }
    }
}
