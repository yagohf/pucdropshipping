using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using Yagohf.PUC.Integracoes.Api.Infraestrutura.Autenticacao;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public UsuariosController(IAutenticacaoService autenticacaoService)
        {
            this._autenticacaoService = autenticacaoService;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        [SwaggerResponse(200, typeof(TokenGerado))]
        [SwaggerResponse(401, Description = "Ocorre quando o usuário não consegue se autenticar por conta de informações incorretas.")]
        public IActionResult Authenticate([FromBody]Autenticacao autenticacao)
        {
            var token = this._autenticacaoService.Autenticar(autenticacao);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
