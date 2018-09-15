using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class ProdutoCategoria : DominioBase
    {
        //Relacionamentos.
        public ICollection<Produto> Produtos { get; set; }
    }
}
