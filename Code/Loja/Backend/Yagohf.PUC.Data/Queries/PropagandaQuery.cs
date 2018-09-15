using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Queries
{
    public class PropagandaQuery : IPropagandaQuery
    {
        public IQuery<Propaganda> ListarAtivas()
        {
            return new Query<Propaganda>()
               .Filtrar(x => x.Ativo)
               .OrdenarPor(x => x.Posicao);
        }
    }
}
