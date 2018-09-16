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
using Yagohf.PUC.Infraestrutura.Configuration;

namespace Yagohf.PUC.Injector
{
    public static class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Context EF Core
            services.AddDbContext<LojaDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DropshippingDB"));
            });

            //Data - Repository
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoCategoriaRepository, ProdutoCategoriaRepository>();
            services.AddScoped<IPromocaoRepository, PromocaoRepository>();
            services.AddScoped<IPropagandaRepository, PropagandaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoFornecedorRepository, PedidoFornecedorRepository>();
            services.AddScoped<IPedidoFornecedorEventoRepository, PedidoFornecedorEventoRepository>();

            //Data - queries.
            services.AddScoped<IPromocaoQuery, PromocaoQuery>();
            services.AddScoped<IPedidoQuery, PedidoQuery>();
            services.AddScoped<IPropagandaQuery, PropagandaQuery>();

            //Data - outros.
            services.AddScoped<ITransactionContainer, TransactionContainer>();

            //Business
            services.AddScoped<IProdutoBusiness, ProdutoBusiness>();
            services.AddScoped<IProdutoCategoriaBusiness, ProdutoCategoriaBusiness>();
            services.AddScoped<IPromocaoBusiness, PromocaoBusiness>();
            services.AddScoped<IPropagandaBusiness, PropagandaBusiness>();
            services.AddScoped<IPedidoBusiness, PedidoBusiness>();

            //Configurações
            ServidorArquivosEstaticosConfiguration servidorArquivosConfiguration = new ServidorArquivosEstaticosConfiguration(
                    configuration.GetSection("ServidorArquivosEstaticos:CaminhoImagensProdutos").Value,
                    configuration.GetSection("ServidorArquivosEstaticos:CaminhoImagensPromocoes").Value,
                    configuration.GetSection("ServidorArquivosEstaticos:CaminhoImagensPropagandas").Value
                    );
            services.AddSingleton<IServidorArquivosEstaticosConfiguration>(servidorArquivosConfiguration);

            //Automapper.
            MapperConfiguration mapperConfiguration = new MapperConfiguration(mConfig =>
            {
                mConfig.AddProfile(new BusinessMapProfile(servidorArquivosConfiguration));
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
