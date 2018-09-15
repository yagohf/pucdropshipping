using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Fornecedor : EntidadeBase
    {
        public bool Ativo { get; set; }
        public string EnderecoConsultarEstoque { get; set; }
        public string EnderecoRealizarPedido { get; set; }
        public string EnderecoCancelarPedido { get; set; }

        //Relacionamentos
        public Pessoa Pessoa { get; set; }
        public ICollection<PedidoFornecedor> PedidosFornecedor { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
