using Yagohf.PUC.Infraestrutura.Validacao;
using System.Collections.Generic;

namespace Yagohf.PUC.Infraestrutura.Exception
{
    public class ValidacaoDTOException : System.Exception
    {
        public IEnumerable<ResultadoValidacaoDTO> ResultadoValidacao { get; }

        public ValidacaoDTOException(IEnumerable<ResultadoValidacaoDTO> resultadoValidacao)
        {
            this.ResultadoValidacao = resultadoValidacao;
        }
    }
}
