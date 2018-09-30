using Amazon.Lambda.Core;
using SGI.Frontend.Infraestrutura.Api.Client;
using System;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Yagohf.PUC.Integracoes.ConsultarEstoque
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            string urlBaseApiAutenticacao = string.Empty;
            Autenticacao autenticacao = new Autenticacao()
            {
                Usuario = "yagohf",
                Senha = "Y@gohf_3107"
            };

            var apiClient = new ApiClient();
            var resultadoAutenticacao = await apiClient.Post<Autenticacao, ResultadoAutenticacao>(urlBaseApiAutenticacao, "/usuarios/autenticar", autenticacao);

            string urlIniciarProcessamento = string.Empty;
            await apiClient.Post<EventoRotina>(urlIniciarProcessamento, "/rotinas/atualizarestoque", new EventoRotina() { Solicitante = "LAMBDA EXECUTADA AUTOMÁTICAMENTE", DataSolicitacao = DateTime.Now });
            return input?.ToUpper();
        }
    }
}
