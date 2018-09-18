using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Queries
{
    public class UsuarioQuery : IUsuarioQuery
    {
        public IQuery<Usuario> PorLoginSenha(string login, string senha)
        {
            return new Query<Usuario>()
                .Filtrar(x => x.Login.Equals(login) && x.Senha.Equals(senha))
                .AdicionarInclude(x => x.UsuarioPerfis);
        }
    }
}
