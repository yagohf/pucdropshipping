using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Usuario;

namespace Yagohf.PUC.Api.Infraestrutura.Autenticacao
{
    public interface IAutenticacaoService
    {
        Task<TokenDTO> Autenticar(AutenticacaoDTO autenticacao);
    }
}
