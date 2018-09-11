using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class ProdutoCategoriaRepository : RepositoryBase<ProdutoCategoria>, IProdutoCategoriaRepository
    {
        public ProdutoCategoriaRepository(LojaDbContext context) : base(context)
        {
        }
    }
}
