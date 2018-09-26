using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Model;
using Yagohf.PUC.Integracoes.Service.Interface.Jobs;

namespace Yagohf.PUC.Integracoes.Service.Jobs
{
    public class ExecutorJobs : IExecutorJobs
    {
        private readonly IJobRepository _jobRepository;
        private readonly IJobFactory _jobFactory;

        public ExecutorJobs(IJobRepository jobRepository, IJobFactory jobFactory)
        {
            this._jobRepository = jobRepository;
            this._jobFactory = jobFactory;
        }

        public void ProcessarExecucoes()
        {
            IEnumerable<Job> jobs = this._jobRepository.RecuperarAtivos();
            foreach (var job in jobs)
            {
                if (this.VerificarMomentoExecutar(job))
                {
                    Task.Factory.StartNew(() =>
                    {
                        IJob jobExecutar = this._jobFactory.Criar((int)job.Id);
                        try
                        {
                            this._jobRepository.AtualizarUltimaExecucao(job.Id);
                            jobExecutar.Executar();
                        }
                        catch
                        {
                            throw; //Relançar a exceção para gravar no centralizador de logs.
                        }
                    }, TaskCreationOptions.LongRunning);
                }
            }
        }

        private bool VerificarMomentoExecutar(Job job)
        {
            if (!job.UltimaExecucao.HasValue)
            {
                return true;
            }
            else
            {
                return (DateTime.Now - job.UltimaExecucao.Value).Minutes >= job.PeriodicidadeMinutos;
            }
        }
    }
}
