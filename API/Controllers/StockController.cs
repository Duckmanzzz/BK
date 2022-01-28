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
    public class StockController : BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _config;
        DataContext db;
        IStockRepositories _IStockRepositories;
        public StockController(IStockRepositories stockRepositories,DataContext datacontext,
                                IConfiguration config,IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            _config = config;
            _IStockRepositories = stockRepositories;
            db = datacontext;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Insert(StockViewModel model)
        {
            var rs =await _IStockRepositories.Insert(model);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var rs =await _IStockRepositories.Delete(Id);
            return Ok(rs);
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rs =await _IStockRepositories.GetAll();
            return Ok(rs);
        }
    }
}
