using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data.Interface
{
    public interface IFornecedorRepository
    {
        IEnumerable<Fornecedor> ListarAtivos();
    }
}
