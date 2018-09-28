using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteBeanstalk.Web.Infraestrutura;

namespace TesteBeanstalk.Web
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "CorsPolicy";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddMvc();

            //Recuperar objeto de configuração e attachar aos serviços.
            var jwtConfigSection = Configuration.GetSection("JwtConfig");
            var jwtConfig = jwtConfigSection.Get<JwtConfig>();
            Configuration.Bind("JwtConfig", jwtConfig);
            services.AddSingleton(jwtConfig);

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
                x.TokenValidationParameters = jwtConfig.TokenValidationParameters;
                //x.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuerSigningKey = true,
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuracoesApp.ChaveCriptografiaToken)),
                //    ValidateIssuer = false,
                //    ValidateAudience = false
                //};
            });

            //Autorização.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CLIENTE", policy => policy.RequireClaim("cognito:groups", "Clientes"));
            });
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
        }
    }
}
