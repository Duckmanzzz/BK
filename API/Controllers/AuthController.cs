
using DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Repositories.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        IUserRespositories _IUserRepositories;
        DataContext db;
        private readonly IConfiguration _config;
        public AuthController(IUserRespositories IUserRespositories, DataContext Datacontext,IConfiguration IConfiguration ,IAuthorizationService authoriazationService)
        {
            _authorizationService = authoriazationService;
            db = Datacontext;
            _IUserRepositories = IUserRespositories;
            _config = IConfiguration;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var result = await _IUserRepositories.Login(login.Username, login.Password);
            if(result == 1)
            {
                var userModel = await _IUserRepositories.GetByName(login.Username);
                return Ok(new
                {
                    result,
                    userName = userModel.UserName,
                    tokenKey = await GenerateJwtAsync(userModel),
                    userId = userModel.UserID,
                    model = userModel
                });
            }
            return Ok(new { result, userName = "", tokenKey = "" });
        }
        #region Private Region

        private async Task<string> GenerateJwtAsync(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescriptor);
            return  tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
