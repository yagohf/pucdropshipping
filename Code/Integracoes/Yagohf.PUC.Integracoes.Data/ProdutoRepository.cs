using System;
using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        public IEnumerable<Produto> ListarAtivosPorFornecedor(int idFornecedor)
        {
            throw new NotImplementedException();
        }

        public void AtualizarDisponibilidade(int idProduto, bool disponibilidade)
        {
            throw new NotImplementedException();
        }
    }
}
