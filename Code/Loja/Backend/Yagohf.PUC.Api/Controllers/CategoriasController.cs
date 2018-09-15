using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly IProdutoCategoriaBusiness _produtoCategoriaBusiness;

        public CategoriasController(IProdutoCategoriaBusiness produtoCategoriaBusiness)
        {
            this._produtoCategoriaBusiness = produtoCategoriaBusiness;
        }

        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(200, typeof(IEnumerable<ProdutoCategoriaDTO>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._produtoCategoriaBusiness.ListarTodosAsync());
        }
    }
}
