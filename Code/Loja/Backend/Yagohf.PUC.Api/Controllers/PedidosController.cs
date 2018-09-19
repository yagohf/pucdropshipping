using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using Yagohf.PUC.Api.Infraestrutura.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.DTO.PedidoFornecedor;
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
        [HttpGet("cliente/{cliente}")]
        [SwaggerResponse(200, typeof(Listagem<PedidoListagemClienteDTO>))]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário que tenta visualizar os pedidos do cliente não é o próprio cliente.")]
        [Authorize(Policy = "CLIENTE")]
        public async Task<IActionResult> GetPorCliente(int cliente, int? pagina)
        {
            int idClienteLogado = this.ObterUsuarioLogado();
            if (idClienteLogado != cliente)
            {
                return Forbid();
            }

            return Ok(await this._pedidoBusiness.ListarPorClienteAsync(idClienteLogado, pagina ?? 1));
        }

        /// <summary>
        /// Consulta todos os pedidos relacionados ao vendedor logado.
        /// </summary>
        [HttpGet("vendedor/{vendedor}")]
        [SwaggerResponse(200, typeof(Listagem<PedidoListagemClienteDTO>))]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário que tenta visualizar os pedidos do vendedor não é o próprio vendedor.")]
        [Authorize(Policy = "VENDEDOR")]
        public async Task<IActionResult> GetPorVendedor(int vendedor, int? pagina)
        {
            int idVendedorLogado = this.ObterUsuarioLogado();
            if (idVendedorLogado != vendedor)
            {
                return Forbid();
            }

            return Ok(await this._pedidoBusiness.ListarPorVendedorAsync(idVendedorLogado, pagina ?? 1));
        }

        /// <summary>
        /// Cria um novo evento de alteração no status de um pedido. Somente acessível por fornecedores autenticados.
        /// </summary>
        /// <param name="model">Dados do evento de alteração do status.</param>
        [HttpPost]
        [SwaggerResponse(200)]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário que tenta registrar um evento não é o fornecedor do pedido informado.")]
        [Authorize(Policy = "FORNECEDOR")]
        public async Task<IActionResult> Post([FromBody]RegistroEventoPedidoFornecedorDTO model)
        {
            int idFornecedorLogado = this.ObterUsuarioLogado();
            if (!await this._pedidoBusiness.VerificarFornecedorResponsavelPorPedido(idFornecedorLogado, model.ChavePedidoFornecedor))
            {
                return Forbid();
            }

            EventoPedidoFornecedorRegistradoDTO eventoCriado = await this._pedidoBusiness.RegistrarEventoAsync(idFornecedorLogado, model);
            return Ok(eventoCriado);
        }
    }
}
