using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Infraestrutura.SMS;

namespace Yagohf.PUC.Integracoes.Test
{
    [TestClass]
    public class AwsSmsNotificadorTest
    {
        private readonly Mock<ILogger<AwsSmsNotificador>> _mockLogger;

        public AwsSmsNotificadorTest()
        {
            this._mockLogger = new Mock<ILogger<AwsSmsNotificador>>();
        }

        [TestMethod]
        public async Task Notificar_Test()
        {
            //Arrange.
            //this._mockLogger.Setup(log => log.LogInformation(It.IsAny<string>())).Verifiable();
            //this._mockLogger.Setup(log => log.LogError(It.IsAny<string>())).Verifiable();
            AwsSmsNotificador awsSmsNotificador = new AwsSmsNotificador(this._mockLogger.Object, new Infraestrutura.Configuration.ConfiguracoesApp()
            {
                AWS = new Infraestrutura.Configuration.ConfiguracoesAws()
                {
                    SMS = new Infraestrutura.Configuration.ConfiguracoesAwsSMS()
                    {
                        Region = "us-east-1",
                        Usuario = "SUBSTITUIR POR USUARIO DO SNS",
                        Senha = "SUBSTITUIR POR SENHA DO SNS"
                    }
                }
            });

            //Act.
            bool finalizou = false;
            await awsSmsNotificador.Notificar("+5516997304540", "Mensagem vinda do Unit Test");
            finalizou = true;

            //Assert.
            Assert.IsTrue(finalizou);
        }
    }
}
