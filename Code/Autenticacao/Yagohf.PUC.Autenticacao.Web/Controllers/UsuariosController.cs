using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using Yagohf.PUC.Autenticacao.Infraestrutura.Configuracoes;
using Yagohf.PUC.Autenticacao.Model;
using Yagohf.PUC.Autenticacao.Service.Interface;

namespace Yagohf.PUC.Autenticacao.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly AwsConfigAdapter _configAdapter;

        public UsuariosController(ILoginService loginService, AwsConfigAdapter configAdapter)
        {
            this._loginService = loginService;
            this._configAdapter = configAdapter;
        }

        [HttpPost("autenticar")]
        [SwaggerResponse(200, typeof(ResultadoAutenticacaoDTO))]
        [SwaggerResponse(401, Description = "Ocorre quando o usuário não consegue se autenticar por conta de informações incorretas.")]
        public async Task<IActionResult> Autenticar([FromBody]AutenticacaoDTO autenticacao)
        {
            var token = await this._loginService.Autenticar(autenticacao);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet]
        public IActionResult Teste()
        {
            return Ok($"Config: { JsonConvert.SerializeObject(this._configAdapter) }");
        }
    }
}
