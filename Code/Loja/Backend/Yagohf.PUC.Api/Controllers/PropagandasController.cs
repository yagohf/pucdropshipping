using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Propaganda;

namespace Yagohf.PUC.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class PropagandasController : Controller
    {
        private readonly IPropagandaBusiness _propagandaBusiness;

        public PropagandasController(IPropagandaBusiness propagandaBusiness)
        {
            this._propagandaBusiness = propagandaBusiness;
        }

        /// <summary>
        /// Consulta todas as propagandas vigentes.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(200, typeof(IEnumerable<PropagandaDTO>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._propagandaBusiness.ListarTodasAtivasAsync());
        }
    }
}
