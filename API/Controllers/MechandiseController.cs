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
    public class MechandiseController : BaseController
    {
         IMechandiseRepositories _mechandiseRepositories;
        private readonly IAuthorizationService _authorizationService;
        DataContext db;
        private readonly IConfiguration _config;
        public MechandiseController(DataContext dataContext,IConfiguration configuration,
            IMechandiseRepositories mechandiseRepositories,IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _config = configuration;
            db = dataContext;
            _mechandiseRepositories = mechandiseRepositories;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Insert(MechandiseViewModel model)
        {
            var rs = await _mechandiseRepositories.Insert(model);
            return Ok(rs);
        }
    }
}
