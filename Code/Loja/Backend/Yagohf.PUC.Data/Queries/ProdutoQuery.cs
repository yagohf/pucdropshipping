using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Queries
{
    public class ProdutoQuery : IProdutoQuery
    {
        public IQuery<Produto> PorId(int id)
        {
            return new Query<Produto>()
              .Filtrar(x => x.Id == id);
        }
    }
}
