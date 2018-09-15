using System;
using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Pedido : EntidadeBase
    {
        public int IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorPago { get; set; }

        //Relacionamentos.
        public Pagamento Pagamento { get; set; }
        public PedidoEndereco PedidoEndereco { get; set; }
        public Pessoa Cliente { get; set; }
        public Pessoa Vendedor { get; set; }
        public ICollection<PedidoItem> PedidoItens { get; set; }
    }
}
