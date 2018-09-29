using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using Yagohf.PUC.Api.Infraestrutura.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoBusiness _pedidoBusiness;

        public PedidosController(IPedidoBusiness pedidoBusiness)
        {
            this._pedidoBusiness = pedidoBusiness;
        }

        /// <summary>
        /// Consulta todos os pedidos relacionados ao cliente logado.
        /// </summary>
        [HttpGet("cliente")]
        [SwaggerResponse(200, typeof(Listagem<PedidoListagemClienteDTO>))]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário autenticado que tenta visualizar os pedidos do cliente não pertence ao grupo de clientes.")]
        [Authorize(Policy = "CLIENTE")]
        public async Task<IActionResult> GetPorCliente(int? pagina)
        {
            return Ok(await this._pedidoBusiness.ListarPorClienteAsync(this.ObterUsuarioLogado(), pagina ?? 1));
        }

        /// <summary>
        /// Consulta todos os pedidos relacionados ao vendedor logado.
        /// </summary>
        [HttpGet("vendedor")]
        [SwaggerResponse(200, typeof(Listagem<PedidoListagemClienteDTO>))]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário autenticado que tenta visualizar os pedidos do vendedor não pertence ao grupo de vendedor.")]
        [Authorize(Policy = "VENDEDOR")]
        public async Task<IActionResult> GetPorVendedor(int vendedor, int? pagina)
        {
            return Ok(await this._pedidoBusiness.ListarPorVendedorAsync(this.ObterUsuarioLogado(), pagina ?? 1));
        }
    }
}
