using Microsoft.VisualStudio.TestTools.UnitTesting;
using SGI.Frontend.Infraestrutura.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.ConsultarEstoque.Models;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Test
{
    [TestClass]
    public class ApiClientTest
    {
        [TestMethod]
        public async Task Post_PegarToken_Test()
        {
            string urlTeste = "http://dropshippingautenticador-env.c32yfhveas.us-east-1.elasticbeanstalk.com/api/v1";
            string pathTeste = "/usuarios/autenticar";
            var modelTeste = new Autenticacao()
            {
                Usuario = "lambda.atualizarestoque",
                Senha = "Y@gohf_3107"
            };

            ApiClient apiClient = new ApiClient();
            var retorno = await apiClient.Post<Autenticacao, ResultadoAutenticacao>(urlTeste, pathTeste, modelTeste);

            Assert.IsNotNull(retorno);
            Assert.AreEqual(retorno.Status, EnumResultadoAutenticacao.SUCESSO);
            Assert.IsNotNull(retorno.Token);
        }

        [TestMethod]
        public async Task Post_DispararProcessamento_Test()
        {
            string urlBaseApiAutenticacao = "http://dropshippingautenticador-env.c32yfhveas.us-east-1.elasticbeanstalk.com/api/v1";
            string usuarioServico = "lambda.atualizarestoque";
            string senhaServico = "Y@gohf_3107";
            string urlIniciarProcessamento = "http://dropshippinginteg-env.vxtc3gwka3.us-east-1.elasticbeanstalk.com/api/v1";

            Autenticacao autenticacao = new Autenticacao()
            {
                Usuario = usuarioServico,
                Senha = senhaServico
            };

            var apiClient = new ApiClient();
            var resultadoAutenticacao = await apiClient.Post<Autenticacao, ResultadoAutenticacao>(
                urlBaseApiAutenticacao, 
                "/usuarios/autenticar", 
                autenticacao);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", $"Bearer { resultadoAutenticacao.Token }");

            string resultado = await apiClient.Post<EventoRotinaIn, string>(
                urlIniciarProcessamento,
                "/rotinas/atualizarestoque",
                new EventoRotinaIn()
                {
                    Solicitante = usuarioServico,
                    DataSolicitacao = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                },
                headers);

            Assert.IsNotNull(resultado);
        }
    }
}
