using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yagohf.PUC.Infraestrutura.Validacao
{
    public interface IValidador<T> where T : class
    {
        Task<bool> ValidarAsync(T objeto);
        IEnumerable<ResultadoValidacaoDTO> Erros { get; }
    }
}