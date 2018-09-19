using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Yagohf.PUC.Api.Infraestrutura.Binders.Providers;
using Yagohf.PUC.Api.Infraestrutura.Filters;
using Yagohf.PUC.Api.Infraestrutura.Swagger.Filters;
using Yagohf.PUC.Injector.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using Yagohf.PUC.Infraestrutura.Configuration;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Yagohf.PUC.Api.Infraestrutura.Autenticacao;

namespace Yagohf.PUC.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger.
            services.AddSwaggerGen(cfg =>
            {
                cfg.OperationFilter<SwaggerConsumesOperationFilter>();
                cfg.OperationFilter<FormFileOperationFilter>();
                cfg.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "API do SGI", Version = "v1", Description = "API do Sistema de Gestão de Infraestrutura" });
                cfg.IncludeXmlComments(MontarPathArquivoXmlSwagger());
            });

            //Adicionar MVC para que os controllers da API funcionem.
            services.AddMvc(config =>
            {
                config.Filters.Add<ApiExceptionFilter>();

                //Binders.
                config.ModelBinderProviders.Insert(0, new StringArrayModelBinderProvider());
            });

            //Recuperar objeto de configuração e attachar aos serviços.
            var configuracoesAppSection = Configuration.GetSection("ConfiguracoesApp");
            //services.Configure<ConfiguracoesApp>(configuracoesAppSection);

            var configuracoesApp = configuracoesAppSection.Get<ConfiguracoesApp>();
            Configuration.Bind("ConfiguracoesApp", configuracoesApp);
            services.AddSingleton(configuracoesApp);

            //Adicionar injeção de dependência (delegando as responsabilidades de injetar as demais camadas para uma extensão).
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddInjectorBootstrapper(this.Configuration, configuracoesApp);

            //Adicionar suporte a CORS (Cross-Origin Resource Sharing).
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("CorsPolicy",
                   builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());
            });

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
                options.AddPolicy("CLIENTE", policy => policy.RequireClaim("CLIENTE"));
                options.AddPolicy("VENDEDOR", policy => policy.RequireClaim("VENDEDOR"));
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
