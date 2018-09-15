using System;
using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Produto : EntidadeBase
    {
        public int IdFornecedor { get; set; }
        public string ChaveProdutoFornecedor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdProdutoCategoria { get; set; }
        public bool Ativo { get; set; }

        //Relacionamentos.
        public ProdutoCategoria ProdutoCategoria { get; set; }
        public ICollection<ProdutoPromocao> PromocoesProduto { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public ICollection<PedidoItem> PedidoItens { get; set; }
    }
}
