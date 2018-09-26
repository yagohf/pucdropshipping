using System;
using System.Collections.Generic;
using System.Text;
using Yagohf.PUC.Integracoes.Infraestrutura.Enumeradores;
using Yagohf.PUC.Integracoes.Service.Interface.Jobs;

namespace Yagohf.PUC.Integracoes.Service.Jobs
{
    public class JobFactory : IJobFactory
    {
        private readonly IAtualizarEstoqueJob _atualizarEstoqueJob;

        public JobFactory(IAtualizarEstoqueJob atualizarEstoqueJob)
        {
            this._atualizarEstoqueJob = atualizarEstoqueJob;
        }

        public IJob Criar(int id)
        {
            switch ((EnumJob)id)
            {
                case EnumJob.ATUALIZAR_ESTOQUE:
                    return this._atualizarEstoqueJob;
                default:
                    throw new ArgumentException("Tipo de JOB inválido para fabricar.");
            }
        }
    }
}
