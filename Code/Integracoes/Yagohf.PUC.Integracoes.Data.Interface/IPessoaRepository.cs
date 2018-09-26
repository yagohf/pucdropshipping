using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data.Interface
{
    public interface IPessoaRepository
    {
        Pessoa RecuperarPorId(int id);
    }
}
