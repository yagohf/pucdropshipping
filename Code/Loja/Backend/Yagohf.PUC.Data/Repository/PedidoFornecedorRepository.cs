using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class PedidoFornecedorRepository : RepositoryBase<PedidoFornecedor>, IPedidoFornecedorRepository
    {
        public PedidoFornecedorRepository(LojaDbContext context) : base(context)
        {
        }
    }
}
