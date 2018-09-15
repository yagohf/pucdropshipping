using System;

namespace Yagohf.PUC.Model.Entidades
{
    public class PedidoFornecedorEvento : EntidadeBase
    {
        public int IdPedidoFornecedor { get; set; }
        public int IdPedidoFornecedorStatus { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string InformacoesAdicionais { get; set; }

        //Relacionamentos
        public PedidoFornecedor PedidoFornecedor { get; set; }
        public PedidoFornecedorStatus PedidoFornecedorStatus { get; set; }
    }
}
