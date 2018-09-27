using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yagohf.PUC.Integracoes.Data;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Infraestrutura.SMS;
using Yagohf.PUC.Integracoes.Service.Dominio;
using Yagohf.PUC.Integracoes.Service.Integracoes;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;
using Yagohf.PUC.Integracoes.Service.Interface.Integracoes;
using Yagohf.PUC.Integracoes.Service.Interface.Jobs;
using Yagohf.PUC.Integracoes.Service.Jobs;

namespace Yagohf.PUC.Integracoes.Injector
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Infraestrutura
            services.AddScoped<IConfiguracoesBanco>((x) =>
            {
                return new ConfiguracoesBanco(configuration.GetConnectionString("DropshippingDB"));
            });
            services.AddScoped<ISmsNotificador, AwsSmsNotificador>();

            //Data
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services - dominio
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPedidoService, PedidoService>();

            //Services - jobs
            services.AddScoped<IExecutorJobs, ExecutorJobs>();
            services.AddScoped<IJobFactory, JobFactory>();
            services.AddScoped<IAtualizarEstoqueJob, AtualizarEstoqueJob>();

            //Services - integracoes
            services.AddScoped<IConsultarEstoqueIntegracao, ConsultarEstoqueIntegracao>();
        }
    }
}
