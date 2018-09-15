using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Queries
{
    public interface IPropagandaQuery
    {
        IQuery<Propaganda> ListarAtivas();
    }
}
