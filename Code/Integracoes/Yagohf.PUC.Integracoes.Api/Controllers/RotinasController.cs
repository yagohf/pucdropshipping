using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;

namespace Yagohf.PUC.Integracoes.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class RotinasController : Controller
    {
        private readonly IAtualizarEstoqueService _atualizarEstoqueService;

        public RotinasController(IAtualizarEstoqueService atualizarEstoqueService)
        {
            this._atualizarEstoqueService = atualizarEstoqueService;
        }

        /// <summary>
        /// Inicia a execução automática do processamento de atualização de estoque.
        /// </summary>
        [HttpPost("atualizarestoque")]
        [SwaggerResponse(200)]
        [SwaggerResponse(403, Description = "Ocorre quando o usuário autenticado não tem permissão de sistema.")]
        [Authorize(Policy = "SISTEMA")]
        public IActionResult Post([FromBody]EventoRotina origem)
        {
            //Disparar processamento em background.
            Task.Factory.StartNew(() =>
            {
                this._atualizarEstoqueService.Executar();
            }, TaskCreationOptions.LongRunning);

            return Ok($"Processamento iniciado por {origem.Solicitante} às { origem.DataSolicitacao }");
        }
    }
}
