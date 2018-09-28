using System.Threading.Tasks;
using Yagohf.PUC.Autenticacao.Model;

namespace Yagohf.PUC.Autenticacao.Service.Interface
{
    public interface ILoginService
    {
        Task<ResultadoAutenticacaoDTO> Autenticar(AutenticacaoDTO autenticacao);
    }
}
