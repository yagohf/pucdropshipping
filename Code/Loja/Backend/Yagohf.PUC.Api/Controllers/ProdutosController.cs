using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController : Controller
    {
        private const int QTD_REGISTROS_DEFAULT_EXIBIR_MAIS_VENDIDOS = 9;
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutosController(IProdutoBusiness produtoBusiness)
        {
            this._produtoBusiness = produtoBusiness;
        }

        /// <summary>
        /// Consulta produtos através de múltiplos parâmetros. Permite paginação.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="ordenacao">Ordenação para exibição dos resultados.</param>
        /// <param name="pagina">Número da página que se deseja exibir.</param>
        [HttpGet]
        [SwaggerResponse(200, typeof(Listagem<ProdutoCatalogoDTO>))]
        public async Task<IActionResult> Get(string nome, string ordenacao, int? pagina)
        {
            return Ok(await this._produtoBusiness.ListarCatalogoAsync(nome, ordenacao, pagina ?? 1));
        }

        /// <summary>
        /// Consulta os produtos mais vendidos para exibição na tela principal do sistema.
        /// </summary>
        [HttpGet("maisvendidos")]
        [SwaggerResponse(200, typeof(IEnumerable<ProdutoCatalogoDTO>))]
        public async Task<IActionResult> GetMaisVendidos(int? quantidadeRegistrosExibir)
        {
            return Ok(await this._produtoBusiness.ListarCatalogoMaisVendidosAsync(quantidadeRegistrosExibir ?? QTD_REGISTROS_DEFAULT_EXIBIR_MAIS_VENDIDOS));
        }

        /// <summary>
        /// Consulta os produtos de uma categoria específica.
        /// </summary>
        /// <param name="categoria">Identificador único da categoria para listagem de produtos.</param>
        /// <param name="ordenacao">Ordenação para exibição dos resultados.</param>
        /// <param name="pagina">Número da página que se deseja exibir.</param>
        [HttpGet("categoria/{categoria}")]
        [SwaggerResponse(200, typeof(Listagem<ProdutoCatalogoDTO>))]
        public async Task<IActionResult> ListarPorCategoria(int categoria, string ordenacao, int? pagina)
        {
            return Ok(await this._produtoBusiness.ListarCatalogoPorCategoriaAsync(categoria, ordenacao, pagina ?? 1));
        }

        /// <summary>
        /// Consulta os produtos de uma promoção específica.
        /// </summary>
        /// <param name="promocao">Identificador único da promoção para listagem de produtos.</param>
        /// <param name="ordenacao">Ordenação para exibição dos resultados.</param>
        /// <param name="pagina">Número da página que se deseja exibir.</param>
        [HttpGet("promocao/{promocao}")]
        [SwaggerResponse(200, typeof(ProdutoCatalogoDTO))]
        public async Task<IActionResult> ListarPorPromocao(int promocao, string ordenacao, int? pagina)
        {
            return Ok(await this._produtoBusiness.ListarParaCatalogoPorPromocaoAsync(promocao, ordenacao, pagina ?? 1));
        }
    }
}
