using System.Collections.Generic;

namespace Yagohf.PUC.Model.Infraestrutura
{
    public class Listagem<T>
    {
        private readonly IEnumerable<T> _lista;
        private readonly Paginacao _paginacao;

        public Listagem(IEnumerable<T> lista) : this(lista, null)
        {

        }

        public Listagem(IEnumerable<T> lista, Paginacao paginacao)
        {
            this._lista = lista;
            this._paginacao = paginacao;
        }

        public IEnumerable<T> Lista { get { return this._lista; } }
        public Paginacao Paginacao { get { return this._paginacao; } }
    }
}
