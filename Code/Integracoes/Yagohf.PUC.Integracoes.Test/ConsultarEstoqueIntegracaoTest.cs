using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yagohf.PUC.Integracoes.Service.Integracoes;

namespace Yagohf.PUC.Integracoes.Test
{
    [TestClass]
    public class ConsultarEstoqueIntegracaoTest
    {
        [TestMethod]
        public void Consultar_AWS_Test()
        {
            ConsultarEstoqueIntegracao consultarEstoqueIntegracao = new ConsultarEstoqueIntegracao();
            bool disponivel = consultarEstoqueIntegracao.Consultar(
                "http://dropshippingfornecedor-env.pr3jhpmmpd.us-east-1.elasticbeanstalk.com/EstoqueService.svc",
                "integracoes.pucdrop",
                "123mudar",
                "PROD0017");

            Assert.IsTrue(disponivel);
        }
    }
}
