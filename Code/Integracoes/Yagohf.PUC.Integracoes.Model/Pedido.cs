﻿using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;

namespace Yagohf.PUC.Integracoes.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdFornecedor { get; set; }
        public int IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public string ChavePedidoFornecedor { get; set; }
        public EnumStatusPedidoFornecedor Status { get; set; }
    }
}
