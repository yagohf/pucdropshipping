using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yagohf.PUC.Business.Dominio;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Business.Mappings;
using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Data.Interface.TransactionContainer;
using Yagohf.PUC.Data.Queries;
using Yagohf.PUC.Data.Repository;
using Yagohf.PUC.Data.TransactionContainer;

namespace Yagohf.PUC.Injector
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Context EF Core
            services.AddDbContext<LojaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SGIDB"));
            });

            //Data - Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Data - queries.
            services.AddScoped<IProdutoQuery, ProdutoQuery>();

            //Data - outros.
            services.AddScoped<ITransactionContainer, TransactionContainer>();

            //Business
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();

            //Automapper.
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mConfig =>
            {
                mConfig.AddProfile(new BusinessMapProfile());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
