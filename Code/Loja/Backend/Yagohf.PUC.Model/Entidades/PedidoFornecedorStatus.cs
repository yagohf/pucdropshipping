using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoFornecedorStatus : DominioBase
    {
        //Relacionamentos
        public ICollection<PedidoFornecedor> PedidosFornecedores { get; set; }
        public ICollection<PedidoFornecedorEvento> PedidosFornecedoresEventos { get; set; }
    }
}
