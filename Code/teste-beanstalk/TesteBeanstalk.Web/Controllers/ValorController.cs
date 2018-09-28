using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBeanstalk.Web.Models;

namespace TesteBeanstalk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class ValorController : Controller
    {
        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var lista = new List<EntidadeRetorno>();
            for (int i = 0; i < 100; i++)
            {
                lista.Add(new EntidadeRetorno() { Texto = $"Item {i}" });
            }

            return Ok(lista);
        }

        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet("parametro")]
        public IActionResult GetComParametro(int p)
        {
            var entidade = new EntidadeRetorno() { Texto = $"Parâmetro enviado: {p}" };
            return Ok(entidade);
        }

        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet("protegida")]
        public IActionResult GetProtegido()
        {
            var entidade = new EntidadeRetorno() { Texto = "Esta é uma rota protegida !" };
            return Ok(entidade);
        }

        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet("usuariologado")]
        public IActionResult GetUsuarioLogado()
        {
            string retorno = string.Empty;
            try
            {
                retorno += $"Name: {HttpContext.User.Identity.Name}\n";
                retorno += $"Claims: { JsonConvert.SerializeObject(HttpContext.User.Claims) }";
            }
            catch (System.Exception ex)
            {
                retorno = ex.Message;
            }
            return Ok(retorno);
        }

        /// <summary>
        /// Consulta todas as categorias de produtos disponíveis.
        /// </summary>
        [HttpGet("validarrole")]
        [Authorize(Policy = "CLIENTE")]
        public IActionResult ValidarRole()
        {
            string retorno = string.Empty;
            try
            {
                retorno += "Usuário autenticado !";
                retorno += $"Name: {HttpContext.User.Identity.Name}\n";
                retorno += $"Claims: { JsonConvert.SerializeObject(HttpContext.User.Claims) }";
            }
            catch (System.Exception ex)
            {
                retorno = ex.Message;
            }
            return Ok(retorno);
        }
    }
}
