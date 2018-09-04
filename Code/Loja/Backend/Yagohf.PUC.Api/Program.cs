using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.IO;

namespace Yagohf.PUC.Api
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();

        public static void Main(string[] args)
        {
            ConfigurarSerilog();

            try
            {
                Log.Information("Main - Startando aplicação...");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Main - Aplicação encontrou uma exceção e encerrou a execução...");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigurarSerilog()
        {
            var serilogColumnOptions = new ColumnOptions();
            //Remover coluna de XML.
            serilogColumnOptions.Store.Remove(StandardColumn.Properties);

            //Adicionar coluna com objeto JSON.
            serilogColumnOptions.Store.Add(StandardColumn.LogEvent);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(
                    connectionString: Configuration.GetConnectionString("LogDB"),
                    tableName: Configuration.GetSection("Serilog:LogTableName").Value ?? "Log",
                    autoCreateSqlTable: false,
                    columnOptions: serilogColumnOptions)
                .CreateLogger();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>()
                .UseConfiguration(Configuration)
                .Build();

            return webHostBuilder;
        }
    }
}
