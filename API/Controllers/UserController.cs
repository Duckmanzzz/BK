using DLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Repositories.Interfaces;
using Services.ViewModels;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        IUserRespositories _IUserRepositories;
        DataContext db;
        private readonly IConfiguration _config;
        public UserController(IAuthorizationService authorizationService,IUserRespositories userRespositories,DataContext
             datacontext,IConfiguration configuration)
        {
            _IUserRepositories = userRespositories;
            _authorizationService = authorizationService;
            db = datacontext;
            _config = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Insert(UserViewModel model)
        {
            var rs = await _IUserRepositories.Insert(model);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update(UserViewModel model)
        {
            var rs = await _IUserRepositories.Update(model);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var rs = await _IUserRepositories.Delete(Id);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpGet("GetByName/{username}")]
        public async Task<IActionResult> GetByName(string username)
        {
            var rs = await _IUserRepositories.GetByName(username);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var rs = await _IUserRepositories.GetById(Id);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpGet("CheckUserName/{username}")]
        public async Task<IActionResult> CheckUsername(string username)
        {
            var rs = await _IUserRepositories.CheckUsername(username);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpGet("CheckPass/{password}")]
        public async Task<IActionResult> CheckPassword(string password,string username)
        {
            var rs = await _IUserRepositories.CheckPassword(password, username);
            return Ok(rs);
        }
    }
}
