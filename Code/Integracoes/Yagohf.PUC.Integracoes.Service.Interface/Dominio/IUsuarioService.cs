using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Service.Interface.Dominio
{
    public interface IUsuarioService
    {
        Usuario Validar(Autenticacao autenticacao);
    }
}
