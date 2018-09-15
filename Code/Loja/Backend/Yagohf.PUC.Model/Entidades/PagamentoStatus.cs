using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class PagamentoStatus : DominioBase
    {
        //Relacionamentos.
        public ICollection<Pagamento> Pagamentos { get; set; }
        public ICollection<PagamentoEvento> PagamentosEventos { get; set; }
    }
}
