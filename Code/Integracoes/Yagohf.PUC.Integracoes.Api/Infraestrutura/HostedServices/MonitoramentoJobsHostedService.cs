using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Service.Interface.Jobs;

namespace Yagohf.PUC.Integracoes.Api.Infraestrutura.HostedServices
{
    public class MonitoramentoJobsHostedService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MonitoramentoJobsHostedService> _logger;
        private Timer _timer;

        public MonitoramentoJobsHostedService(IServiceProvider serviceProvider, ILogger<MonitoramentoJobsHostedService> logger)
        {
            this._serviceProvider = serviceProvider;
            this._logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("#### INTEGRAÇÕES ####: serviço de monitoramento de jobs iniciado.");
            _timer = new Timer(Executar, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void Executar(object state)
        {
            try
            {
                using (var scope = this._serviceProvider.CreateScope())
                {
                    this._logger.LogInformation("#### INTEGRAÇÕES ####: iniciando ciclo de monitoramento de jobs.");
                    IExecutorJobs executorJobs = scope.ServiceProvider.GetRequiredService<IExecutorJobs>();
                    executorJobs.ProcessarExecucoes();
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "#### INTEGRAÇÕES ####: OCORREU UM ERRO NA EXECUÇÃO DE UM DOS JOBS.");
            }
            finally
            {
                this._logger.LogInformation("#### INTEGRAÇÕES ####: ciclo de monitoramento de jobs finalizado.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("#### INTEGRAÇÕES ####: SERVIÇO DE MONITORAMENTO DE JOBS ENCERRADO.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
