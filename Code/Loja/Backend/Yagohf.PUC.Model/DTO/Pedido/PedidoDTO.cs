using System;
using Yagohf.PUC.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Model.DTO.Pedido
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusPagamento StatusPagamento { get; set; }
    }
}
