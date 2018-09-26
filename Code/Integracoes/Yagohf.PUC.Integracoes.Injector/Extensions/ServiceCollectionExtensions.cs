using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Yagohf.PUC.Integracoes.Injector.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInjectorBootstrapper(this IServiceCollection services, IConfiguration configuration)
        {
            InjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
