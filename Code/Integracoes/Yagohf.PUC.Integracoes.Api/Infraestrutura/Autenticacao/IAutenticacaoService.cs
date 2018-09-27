using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Api.Infraestrutura.Autenticacao
{
    public interface IAutenticacaoService
    {
        TokenGerado Autenticar(Yagohf.PUC.Integracoes.Model.Autenticacao autenticacao);
    }
}
