using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yagohf.PUC.Integracoes.Data;
using Yagohf.PUC.Integracoes.Data.Interface;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Infraestrutura.Email;
using Yagohf.PUC.Integracoes.Infraestrutura.SMS;
using Yagohf.PUC.Integracoes.Service.Dominio;
using Yagohf.PUC.Integracoes.Service.Integracoes;
using Yagohf.PUC.Integracoes.Service.Interface.Dominio;
using Yagohf.PUC.Integracoes.Service.Interface.Integracoes;

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
            services.AddScoped<IEmailNotificador, EmailNotificador>();

            //Data
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Services - dominio
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IAtualizarEstoqueService, AtualizarEstoqueService>();

            //Services - integracoes
            services.AddScoped<IConsultarEstoqueIntegracao, ConsultarEstoqueIntegracao>();
        }
    }
}
