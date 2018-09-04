using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LojaDbContext context) : base(context)
        {
        }
    }
}
