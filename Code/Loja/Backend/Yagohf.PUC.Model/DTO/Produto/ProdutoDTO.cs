using System;

namespace Yagohf.PUC.Model.DTO.Produto
{
    public class ProdutoDTO
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
    }
}
