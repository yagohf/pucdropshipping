using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Queries
{
    public interface IProdutoQuery
    {
        IQuery<Produto> PorId(int id);
    }
}
