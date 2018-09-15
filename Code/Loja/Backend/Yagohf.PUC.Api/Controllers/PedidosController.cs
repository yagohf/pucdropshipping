using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
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
        [SwaggerResponse(403, Description ="Ocorre quando o usuário que tenta visualizar os pedidos do cliente não é o próprio cliente.")]
        public async Task<IActionResult> GetPorCliente(int cliente, int pagina)
        {
            int idClienteLogado = 0; //TODO - recuperar ID do cliente autenticado e comparar com o enviado no parâmetro.
            if (idClienteLogado != cliente)
            {
                return Forbid();
            }

            return Ok(await this._pedidoBusiness.ListarPorClienteAsync(cliente, pagina));
        }

        /// <summary>
        /// Consulta todos os pedidos relacionados ao vendedor logado.
        /// </summary>
        [HttpGet("vendedor/{vendedor}")]
        [SwaggerResponse(200, typeof(Listagem<PedidoListagemVendedorDTO>))]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário que tenta visualizar os pedidos do vendedor não é o próprio vendedor.")]
        public async Task<IActionResult> GetPorVendedor(int vendedor, int pagina)
        {
            int idVendedorLogado = 0; //TODO - recuperar ID do vendedor autenticado e comparar com o enviado no parâmetro.
            if (idVendedorLogado != vendedor)
            {
                return Forbid();
            }

            return Ok(await this._pedidoBusiness.ListarPorVendedorAsync(vendedor, pagina));
        }

        /// <summary>
        /// Cria um novo evento de alteração no status de um pedido. Somente acessível por fornecedores autenticados.
        /// </summary>
        /// <param name="model">Dados do evento de alteração do status.</param>
        [HttpPost]
        [SwaggerResponse(200)]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário que tenta registrar um evento não é o fornecedor do pedido informado.")]
        public async Task<IActionResult> Post([FromBody]RegistroEventoPedidoFornecedorDTO model)
        {
            int idFornecedorLogado = 0; //TODO - recuperar ID do fornecedor autenticado.
            if (!await this._pedidoBusiness.VerificarFornecedorResponsavelPorPedido(idFornecedorLogado, model.ChavePedidoFornecedor))
            {
                return Forbid();
            }

            EventoPedidoFornecedorRegistradoDTO eventoCriado = await this._pedidoBusiness.Registrar(0, model);
            return Ok(eventoCriado);
        }
    }
}
