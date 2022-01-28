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
    public class UnitController : BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _config;
        DataContext db;
        IUnitRepositories _IUnitRepositories;
        public UnitController(IAuthorizationService authorizationService,DataContext dataContext
            ,IConfiguration config,IUnitRepositories unitRepositories) 
        {
            _authorizationService = authorizationService;
            _config = config;
            db = dataContext;
            _IUnitRepositories = unitRepositories;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Insert(UnitViewModel model)
        {
            var rs = await _IUnitRepositories.Insert(model);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update(UnitViewModel model)
        {
            var rs = await _IUnitRepositories.Update(model);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _IUnitRepositories.GetAll();
            return Ok(rs);
        }
    }
}
