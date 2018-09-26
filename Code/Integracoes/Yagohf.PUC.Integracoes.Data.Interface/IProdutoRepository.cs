using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data.Interface
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> ListarAtivosPorFornecedor(int idFornecedor);
        void AtualizarDisponibilidade(int idProduto, bool disponibilidade);
    }
}
