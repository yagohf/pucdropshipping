using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Pagamento : EntidadeBase
    {
        public int IdPedido { get; set; }
        public int IdPagamentoStatus { get; set; }
        public string ChaveTransacao { get; set; }
        public string DescricaoPagamento { get; set; }
        public string XMLTransacao { get; set; }

        //Relacionamentos.
        public Pedido Pedido { get; set; }
        public PagamentoStatus PagamentoStatus { get; set; }
        public ICollection<PagamentoEstorno> PagamentoEstornos { get; set; }
        public ICollection<PagamentoEvento> PagamentoEventos { get; set; }
    }
}
