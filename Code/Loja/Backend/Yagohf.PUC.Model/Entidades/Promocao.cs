using System;
using System.Collections.Generic;

namespace Yagohf.PUC.Model.Entidades
{
    public class Promocao : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFimPrevisto { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Ativa { get; set; }

        //Relacionamentos.
        public ICollection<ProdutoPromocao> ProdutosPromocao { get; set; }
    }
}
