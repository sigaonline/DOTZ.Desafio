using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Service.Interface.Providers;
using DOTZ.Desafio.Service.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DOTZ.Desafio.API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccessTokenService accessTokenService;
        
        public LoginController(IAccessTokenService accessTokenService, IUserProvider userProvider)
        {
            this.accessTokenService = accessTokenService;
        
        }


        [HttpPost()]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Get([FromBody] LoginRequesty dataObject)
        {
            return await accessTokenService.GenerateToken(dataObject);
        }
        [HttpGet("authenticated")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Authenticate()
        {
            return string.Format("Authenticated - {0}", User.Identity.Name);
        }
    }
}
