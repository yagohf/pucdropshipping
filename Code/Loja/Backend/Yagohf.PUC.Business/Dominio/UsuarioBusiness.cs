using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Infraestrutura.Enumeradores;
using Yagohf.PUC.Model.DTO.Usuario;

namespace Yagohf.PUC.Business.Dominio
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioQuery _usuarioQuery;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository, IUsuarioQuery usuarioQuery)
        {
            this._usuarioRepository = usuarioRepository;
            this._usuarioQuery = usuarioQuery;
        }

        public async Task<UsuarioVerificadoDTO> Validar(AutenticacaoDTO autenticacao)
        {
            var usuarioBanco = await this._usuarioRepository.SelecionarUnicoAsync(this._usuarioQuery.PorLoginSenha(autenticacao.Login, autenticacao.Senha));
            if (usuarioBanco == null)
            {
                return null;
            }

            UsuarioVerificadoDTO usuarioVerificado = new UsuarioVerificadoDTO();
            usuarioVerificado.Id = usuarioBanco.Id;
            usuarioVerificado.Login = autenticacao.Login;
            foreach (var perfil in usuarioBanco.UsuarioPerfis)
            {
                usuarioVerificado.Perfis.Add((EnumPerfil)perfil.IdPerfil);
            }

            return usuarioVerificado;
        }
    }
}
