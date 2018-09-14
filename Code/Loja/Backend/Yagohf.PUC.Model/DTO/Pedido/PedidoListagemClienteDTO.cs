using System;
using Yagohf.PUC.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Model.DTO.Pedido
{
    public class PedidoListagemClienteDTO
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusPagamento StatusPagamento { get; set; }
    }
}
