using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Yagohf.PUC.Integracoes.Infraestrutura.Email;

namespace Yagohf.PUC.Integracoes.Test
{
    [TestClass]
    public class EmailNotificadorTest
    {
        [TestMethod]
        public void Notificar_Test()
        {
            EmailNotificador notificador = new EmailNotificador(new Infraestrutura.Configuration.ConfiguracoesApp()
            {
                AWS = new Infraestrutura.Configuration.ConfiguracoesAws()
                {
                    Email = new Infraestrutura.Configuration.ConfiguracoesAwsEmail()
                    {
                        Servidor= "SERVIDOR DO SES",
                        Usuario = "USUARIO SES",
                        Senha = "SENHA USUARIO SES",
                        NomeRemetente = "Yago Teste",
                        Porta = 587,
                        Remetente = "yagoferreira21@gmail.com"
                    }
                }
            });

            bool chegouAoFinal = false;
            notificador.Notificar("yagoferreira21@gmail.com", "Teste e-mail AWS", "Este é um e-mail de teste para validar a implementação");
            chegouAoFinal = true;
            Assert.IsTrue(chegouAoFinal);
        }
    }
}
