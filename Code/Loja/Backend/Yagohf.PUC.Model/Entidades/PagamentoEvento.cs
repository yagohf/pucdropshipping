using System;

namespace Yagohf.PUC.Model.Entidades
{
    public class PagamentoEvento : EntidadeBase
    {
        public int IdPagamento { get; set; }
        public int IdPagamentoStatus { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string XMLTransacao { get; set; }
    }
}
