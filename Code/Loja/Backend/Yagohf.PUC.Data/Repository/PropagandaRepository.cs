using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class PropagandaRepository : RepositoryBase<Propaganda>, IPropagandaRepository
    {
        public PropagandaRepository(LojaDbContext context) : base(context)
        {
        }
    }
}
