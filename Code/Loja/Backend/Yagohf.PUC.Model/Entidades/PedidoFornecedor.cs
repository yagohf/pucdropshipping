﻿namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoFornecedor : EntidadeBase
    {
        public int IdFornecedor { get; set; }
        public int IdPedido { get; set; }
        public string ChavePedidoFornecedor { get; set; }
        public int IdPedidoFornecedorStatus { get; set; }
    }
}