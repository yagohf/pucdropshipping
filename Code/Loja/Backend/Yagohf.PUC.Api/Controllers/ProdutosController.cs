using Microsoft.AspNetCore.Mvc;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Infraestrutura.Validacao;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Infraestrutura;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoBusiness _produtoBusiness;

        public ProdutosController(IProdutoBusiness produtoBusiness)
        {
            this._produtoBusiness = produtoBusiness;
        }

        /// <summary>
        /// Consulta produtos através de múltiplos parâmetros. Permite paginação.
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <param name="avaliacaoMinima">Avaliação mínima dos usuários para o produto</param>
        /// <param name="ordenacao">Ordenação da exibição dos resultados</param>
        /// <param name="pagina">Página</param>
        [HttpGet]
        [SwaggerResponse(200, typeof(Listagem<ProdutoDTO>))]
        public async Task<IActionResult> Get(string nome, decimal? avaliacaoMinima, string ordenacao, int pagina)
        {
            return Ok(await this._produtoBusiness.ListarAsync(nome, avaliacaoMinima, ordenacao, pagina));
        }

        /// <summary>
        /// Consulta os produtos mais vendidos para exibição na tela principal do sistema.
        /// </summary>
        [HttpGet("/maisvendidos")]
        [SwaggerResponse(200, typeof(ProdutoDTO))]
        public async Task<IActionResult> GetMaisVendidos()
        {
            return Ok(await this._produtoBusiness.ListarMaisVendidosAsync());
        }

        /// <summary>
        /// Consulta os produtos de uma categoria específica.
        /// </summary>
        /// <param name="categoria">Identificador único da categoria para listagem de produtos.</param>
        [HttpGet("/categoria/{categoria}")]
        [SwaggerResponse(200, typeof(ProdutoDTO))]
        public async Task<IActionResult> ListarPorCategoria(int categoria)
        {
            return Ok(await this._produtoBusiness.ListarPorCategoriaAsync(categoria));
        }
    }
}
