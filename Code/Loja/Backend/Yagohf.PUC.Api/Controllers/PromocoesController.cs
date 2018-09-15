using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Promocao;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class PromocoesController : Controller
    {
        private readonly IPromocaoBusiness _promocaoBusiness;

        public PromocoesController(IPromocaoBusiness promocaoBusiness)
        {
            this._promocaoBusiness = promocaoBusiness;
        }

        /// <summary>
        /// Consulta todas as promoções de produtos disponíveis.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(200, typeof(IEnumerable<PromocaoDTO>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._promocaoBusiness.ListarTodasAtivasAsync());
        }
    }
}
