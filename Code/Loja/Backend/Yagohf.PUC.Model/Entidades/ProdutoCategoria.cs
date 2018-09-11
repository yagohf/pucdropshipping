using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class ProdutoCategoria : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        //Relacionamentos.
        public ICollection<Produto> Produtos { get; set; }
    }
}
