using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yagohf.PUC.Infraestrutura.Configuration;

namespace Yagohf.PUC.Injector.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInjectorBootstrapper(this IServiceCollection services, IConfiguration configuration, ConfigAdapter configuracoesApp)
        {
            InjectorBootStrapper.RegisterServices(services, configuration, configuracoesApp);
        }
    }
}
