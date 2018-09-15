using System;

namespace Yagohf.PUC.Model.Entidades
{
    public class PagamentoEstorno : EntidadeBase
    {
        public int IdPagamento { get; set; }
        public int IdPedidoItem { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string XMLTransacao { get; set; }

        //Relacionamentos.
        public Pagamento Pagamento { get; set; }
        public PedidoItem PedidoItem { get; set; }
    }
}
