using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data.Interface
{
    public interface IJobRepository
    {
        IEnumerable<Job> RecuperarAtivos();
        void AtualizarUltimaExecucao(int idJob);
    }
}
