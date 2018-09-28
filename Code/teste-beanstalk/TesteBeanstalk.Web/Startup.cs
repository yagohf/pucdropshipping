using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace TesteBeanstalk.Web
{
    public class Startup
    {
        private const string CORS_POLICY_NAME = "CorsPolicy";

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORS_POLICY_NAME);
            app.UseMvc();
        }
    }
}
