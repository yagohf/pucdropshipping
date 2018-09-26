using System;
using System.Collections.Generic;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Data
{
    public class JobRepository : IJobRepository
    {
        public void AtualizarUltimaExecucao(int idJob)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> RecuperarAtivos()
        {
            throw new NotImplementedException();
        }
    }
}
