using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yagohf.PUC.Integracoes.Api.Infraestrutura.Autenticacao;
using Yagohf.PUC.Integracoes.Api.Infraestrutura.Filters;
using Yagohf.PUC.Integracoes.Api.Infraestrutura.HostedServices;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;
using Yagohf.PUC.Integracoes.Injector.Extensions;

namespace Yagohf.PUC.Integracoes.Api
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger.
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "API de integrações - PUC Minas", Version = "v1", Description = "API de integrações - PUC Minas" });
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
            var configuracoesAppSection = Configuration.GetSection("ConfiguracoesApp");

            var configuracoesApp = configuracoesAppSection.Get<ConfiguracoesApp>();
            Configuration.Bind("ConfiguracoesApp", configuracoesApp);
            services.AddSingleton(configuracoesApp);

            services.AddScoped<IAutenticacaoService, AutenticacaoService>();

            services.AddInjectorBootstrapper(this.Configuration);
            services.AddHostedService<MonitoramentoJobsHostedService>();

            //Autenticação.
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
#if DEBUG
                x.RequireHttpsMetadata = false;
#endif
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuracoesApp.ChaveCriptografiaToken)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Autorização.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("FORNECEDOR", policy => policy.RequireClaim("FORNECEDOR"));
            });
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
