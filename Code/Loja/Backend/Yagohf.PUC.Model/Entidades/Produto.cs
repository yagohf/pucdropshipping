using System;
using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Produto : EntidadeBase
    {
        public int IdFornecedor { get; set; }
        public string ChaveFornecedor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdProdutoCategoria { get; set; }
        public bool Ativo { get; set; }

        //Relacionamentos.
        public ProdutoCategoria Categoria { get; set; }
        public ICollection<ProdutoPromocao> PromocoesProduto { get; set; }
    }
}
