using Microsoft.AspNetCore.Mvc;
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
    }
}
