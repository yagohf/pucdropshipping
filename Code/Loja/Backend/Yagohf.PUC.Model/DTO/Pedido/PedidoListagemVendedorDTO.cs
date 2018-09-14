using System;
using Yagohf.PUC.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Model.DTO.Pedido
{
    public class PedidoListagemVendedorDTO
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusPagamento StatusPagamento { get; set; }
    }
}
