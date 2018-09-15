using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Queries
{
    public class PromocaoQuery : Query<Promocao>, IPromocaoQuery
    {
        public IQuery<Promocao> ListarAtivas()
        {
            return new Query<Promocao>()
                .Filtrar(x => x.Ativa)
                .OrdenarPorDescendente(x => x.DataInicio);
        }
    }
}
