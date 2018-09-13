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
        /// Consulta todos os pedidos relacionados ao usuário logado.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(200, typeof(Listagem<PedidoDTO>))]
        public async Task<IActionResult> Get(int pagina)
        {
            //TODO - recuperar ID do usuário autenticado.
            return Ok(await this._pedidoBusiness.ListarAsync(0, pagina));
        }

        /// <summary>
        /// Cria um novo evento de alteração no status de um pedido. Somente acessível por fornecedores autenticados.
        /// </summary>
        /// <param name="model">Dados do evento de alteração do status.</param>
        [HttpPost]
        [SwaggerResponse(200)]
        public async Task<IActionResult> Post([FromBody]RegistroEventoPedidoFornecedorDTO model)
        {
            //TODO - recuperar ID do fornecedor autenticado.
            EventoPedidoFornecedorRegistradoDTO eventoCriado = await this._pedidoBusiness.Registrar(0, model);
            return Ok(eventoCriado);
        }
    }
}
