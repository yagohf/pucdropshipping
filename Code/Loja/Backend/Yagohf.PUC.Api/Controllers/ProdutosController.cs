﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;
using Yagohf.PUC.Model.DTO.Promocao;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoBusiness _produtoBusiness;
        private readonly IProdutoCategoriaBusiness _produtoCategoriaBusiness;
        private readonly IPromocaoBusiness _promocaoBusiness;

        public ProdutosController(IProdutoBusiness produtoBusiness, IProdutoCategoriaBusiness produtoCategoriaBusiness, IPromocaoBusiness promocaoBusiness)
        {
            this._produtoBusiness = produtoBusiness;
            this._produtoCategoriaBusiness = produtoCategoriaBusiness;
            this._promocaoBusiness = promocaoBusiness;
        }

        #region [ Listagem de produtos ]
        /// <summary>
        /// Consulta produtos através de múltiplos parâmetros. Permite paginação.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="ordenacao">Ordenação para exibição dos resultados.</param>
        /// <param name="pagina">Número da página que se deseja exibir.</param>
        [HttpGet]
        [SwaggerResponse(200, typeof(Listagem<ProdutoCatalogoDTO>))]
        public async Task<IActionResult> Get(string nome, string ordenacao, int pagina)
        {
            return Ok(await this._produtoBusiness.ListarAsync(nome, ordenacao, pagina));
        }

        /// <summary>
        /// Consulta os produtos mais vendidos para exibição na tela principal do sistema.
        /// </summary>
        [HttpGet("/maisvendidos")]
        [SwaggerResponse(200, typeof(IEnumerable<ProdutoCatalogoDTO>))]
        public async Task<IActionResult> GetMaisVendidos()
        {
            return Ok(await this._produtoBusiness.ListarMaisVendidosAsync());
        }

        /// <summary>
        /// Consulta os produtos de uma categoria específica.
        /// </summary>
        /// <param name="categoria">Identificador único da categoria para listagem de produtos.</param>
        /// <param name="ordenacao">Ordenação para exibição dos resultados.</param>
        /// <param name="pagina">Número da página que se deseja exibir.</param>
        [HttpGet("/categorias/{categoria}")]
        [SwaggerResponse(200, typeof(Listagem<ProdutoCatalogoDTO>))]
        public async Task<IActionResult> ListarPorCategoria(int categoria, string ordenacao, int pagina)
        {
            return Ok(await this._produtoBusiness.ListarPorCategoriaAsync(categoria, ordenacao, pagina));
        }

        /// <summary>
        /// Consulta os produtos de uma promoção específica.
        /// </summary>
        /// <param name="promocao">Identificador único da promoção para listagem de produtos.</param>
        /// <param name="ordenacao">Ordenação para exibição dos resultados.</param>
        /// <param name="pagina">Número da página que se deseja exibir.</param>
        [HttpGet("/promocoes/{promocao}")]
        [SwaggerResponse(200, typeof(ProdutoCatalogoDTO))]
        public async Task<IActionResult> ListarPorPromocao(int promocao, string ordenacao, int pagina)
        {
            return Ok(await this._produtoBusiness.ListarPorCategoriaAsync(promocao, ordenacao, pagina));
        }
        #endregion

        #region [ Listagem de categorias ]
        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet("/categorias")]
        [SwaggerResponse(200, typeof(IEnumerable<ProdutoCategoriaDTO>))]
        public async Task<IActionResult> GetCategorias()
        {
            return Ok(await this._produtoCategoriaBusiness.ListarTodosAsync());
        }
        #endregion

        #region [ Listagem de promoções ]

        /// <summary>
        /// Consulta todas as promoções de produtos disponíveis.
        /// </summary>
        [HttpGet("/promocoes")]
        [SwaggerResponse(200, typeof(IEnumerable<PromocaoDTO>))]
        public async Task<IActionResult> GetPromocoes()
        {
            return Ok(await this._promocaoBusiness.ListarTodasAtivasAsync());
        }

        #endregion
    }
}
