using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;

namespace Yagohf.PUC.Integracoes.Service.Dominio
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public Usuario Validar(Autenticacao autenticacao)
        {
            Usuario usuario = this._usuarioRepository.RecuperarPorLogin(autenticacao.Login);
            if (usuario == null)
            {
                return null;
            }
            else if (usuario.Senha != autenticacao.Senha)
            {
                return null;
            }

            usuario.Perfis = this._usuarioRepository.RecuperarPerfisPorUsuario(usuario.Login);
            return usuario;
        }
    }
}
