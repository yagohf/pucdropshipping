using System;

namespace Yagohf.PUC.Model.DTO.Pedido
{
    public class PedidoListagemVendedorDTO
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
