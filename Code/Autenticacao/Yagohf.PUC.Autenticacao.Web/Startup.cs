using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using Yagohf.PUC.Autenticacao.Infraestrutura.Configuracoes;
using Yagohf.PUC.Autenticacao.Service;
using Yagohf.PUC.Autenticacao.Service.Interface;
using Yagohf.PUC.Autenticacao.Web.Infraestrutura.Filters;

namespace Yagohf.PUC.Autenticacao.Web
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "CorsPolicy";
        private const string CHAVE_CONFIGURACOES_AWS = "AWS";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger.
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "API de autenticação - Sistema integrado de loja virtual - PUC Minas", Version = "v1", Description = "API para autenticação do sistema integrado de loja virtual - PUC Minas" });
                cfg.IncludeXmlComments(MontarPathArquivoXmlSwagger());
            });

            //Adicionar suporte a CORS (Cross-Origin Resource Sharing).
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy(CORS_POLICY_NAME,
                   builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());
            });

            //Adicionar MVC para que os controllers da API funcionem.
            services.AddMvc(config =>
            {
                config.Filters.Add<ApiExceptionFilter>();
            });

            //Recuperar objeto de configuração e attachar aos serviços.
            services.AddSingleton(ObterObjetoConfiguracaoAWS());

            services.AddScoped<ILoginService, LoginService>();
        }

        private AwsConfigAdapter ObterObjetoConfiguracaoAWS()
        {
            var configAWSSection = Configuration.GetSection(CHAVE_CONFIGURACOES_AWS);
            var configAWS = configAWSSection.Get<AwsConfigAdapter>();
            Configuration.Bind(CHAVE_CONFIGURACOES_AWS, configAWS);
            return configAWS;
        }

        private string MontarPathArquivoXmlSwagger()
        {
            string caminhoAplicacao =
                   PlatformServices.Default.Application.ApplicationBasePath;
            string nomeAplicacao =
                PlatformServices.Default.Application.ApplicationName;
            string caminhoXmlDoc =
                Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

            return caminhoXmlDoc;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(CORS_POLICY_NAME);
            app.UseMvc();

            app.UseSwagger((c) =>
            {
                //Tratamento para setar o basepath no Swagger.
                string basepath = "/api/v1";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.BasePath = basepath);

                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    IDictionary<string, PathItem> paths = new Dictionary<string, PathItem>();
                    foreach (var path in swaggerDoc.Paths)
                    {
                        paths.Add(path.Key.Replace(basepath, ""), path.Value);
                    }

                    swaggerDoc.Paths = paths;
                });
            });

            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "API do SGI - v1");
            });
        }
    }
}
