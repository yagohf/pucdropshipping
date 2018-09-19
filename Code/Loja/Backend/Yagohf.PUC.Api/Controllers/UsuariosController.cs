using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yagohf.PUC.Api.Infraestrutura.Autenticacao;
using Yagohf.PUC.Model.DTO.Usuario;

namespace Yagohf.PUC.Api.Controllers
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
        public async Task<IActionResult> Authenticate([FromBody]AutenticacaoDTO autenticacao)
        {
            var token = await this._autenticacaoService.Autenticar(autenticacao);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
