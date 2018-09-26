using System;
using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public IEnumerable<Pedido> RecuperarPorChaveFornecedor(int idFornecedor, string chavePedido)
        {
            throw new NotImplementedException();
        }

        public void AtualizarStatus(int idPedido, int novoStatus)
        {
            throw new NotImplementedException();
        }
    }
}
