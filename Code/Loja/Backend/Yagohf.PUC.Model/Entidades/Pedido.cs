using System;

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
    }
}
