using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Queries
{
    public interface IUsuarioQuery
    {
        IQuery<Usuario> PorLoginSenha(string login, string senha);
    }
}
