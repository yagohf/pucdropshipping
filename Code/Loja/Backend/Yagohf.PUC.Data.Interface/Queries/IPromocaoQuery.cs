using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Queries
{
    public interface IPromocaoQuery
    {
        IQuery<Promocao> ListarAtivas();
    }
}
