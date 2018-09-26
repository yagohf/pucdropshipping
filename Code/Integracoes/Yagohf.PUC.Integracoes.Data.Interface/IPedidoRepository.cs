using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data.Interface
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> RecuperarPorChaveFornecedor(int idFornecedor, string chavePedido);
        void AtualizarStatus(int idPedido, int novoStatus);
    }
}
