using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoFornecedor : EntidadeBase
    {
        public int IdFornecedor { get; set; }
        public int IdPedidoItem { get; set; }
        public string ChavePedidoFornecedor { get; set; }
        public int IdPedidoFornecedorStatus { get; set; }

        //Relacionamentos
        public Fornecedor Fornecedor { get; set; }
        public PedidoFornecedorStatus PedidoFornecedorStatus { get; set; }
        public ICollection<PedidoFornecedorEvento> PedidoFornecedorEventos { get; set; }
        public PedidoItem PedidoItem { get; set; }
    }
}
