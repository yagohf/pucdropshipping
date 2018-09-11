using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class PromocaoRepository : RepositoryBase<Promocao>, IPromocaoRepository
    {
        public PromocaoRepository(LojaDbContext context) : base(context)
        {
        }
    }
}
