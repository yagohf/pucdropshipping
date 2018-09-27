using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Api.Infraestrutura.Extensions;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;

namespace Yagohf.PUC.Integracoes.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }

        /// <summary>
        /// Cria um novo evento de alteração no status de um pedido. Somente acessível por fornecedores autenticados.
        /// </summary>
        /// <param name="model">Dados do evento de alteração do status.</param>
        [HttpPost("registrarevento")]
        [SwaggerResponse(200)]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário que tenta registrar um evento não é o fornecedor do pedido informado.")]
        [Authorize(Policy = "FORNECEDOR")]
        public async Task<IActionResult> Post([FromBody]RegistroEventoPedidoFornecedor model)
        {
            int idFornecedorLogado = this.ObterUsuarioLogado();
            if (!this._pedidoService.VerificarFornecedorResponsavelPorPedido(idFornecedorLogado, model.ChavePedidoFornecedor))
            {
                return Forbid();
            }

            EventoPedidoFornecedorRegistrado eventoCriado = await this._pedidoService.RegistrarEvento(idFornecedorLogado, model);
            return Ok(eventoCriado);
        }
    }
}
