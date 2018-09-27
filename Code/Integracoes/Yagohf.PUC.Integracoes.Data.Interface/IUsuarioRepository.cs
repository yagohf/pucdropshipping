using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data.Interface
{
    public interface IUsuarioRepository
    {
        Usuario RecuperarPorLogin(string login);
        IEnumerable<EnumPerfil> RecuperarPerfisPorUsuario(string login);
    }
}
