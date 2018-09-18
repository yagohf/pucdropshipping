using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Usuario;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IUsuarioBusiness
    {
        Task<UsuarioVerificadoDTO> Validar(AutenticacaoDTO autenticacao);
    }
}
