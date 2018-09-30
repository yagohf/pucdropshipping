using Amazon.Lambda.Core;
using SGI.Frontend.Infraestrutura.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.ConsultarEstoque.Models;
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
            string urlBaseApiAutenticacao = Environment.GetEnvironmentVariable("URL_BASE_API_AUTENTICACAO");
            string usuarioServico = Environment.GetEnvironmentVariable("USUARIO_SERVICO");
            string senhaServico = Environment.GetEnvironmentVariable("SENHA_SERVICO");
            string urlIniciarProcessamento = Environment.GetEnvironmentVariable("URL_BASE_API_ROTINAS");

            Autenticacao autenticacao = new Autenticacao()
            {
                Usuario = usuarioServico,
                Senha = senhaServico
            };

            var apiClient = new ApiClient();
            var resultadoAutenticacao = await apiClient.Post<Autenticacao, ResultadoAutenticacao>(urlBaseApiAutenticacao, "/usuarios/autenticar", autenticacao);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", $"Bearer { resultadoAutenticacao.Token }");

            string retorno = await apiClient.Post<EventoRotinaIn, string>(
                urlIniciarProcessamento,
                "/rotinas/atualizarestoque",
                new EventoRotinaIn()
                {
                    Solicitante = usuarioServico,
                    DataSolicitacao = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                },
                headers);

            return retorno;
        }
    }
}
