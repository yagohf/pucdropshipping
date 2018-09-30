using System.Net;
using System.Net.Mail;
using Yagohf.PUC.Integracoes.Infraestrutura.Configuration;

namespace Yagohf.PUC.Integracoes.Infraestrutura.Email
{
    public class EmailNotificador : IEmailNotificador
    {
        private readonly ConfiguracoesApp _configuracoesApp;

        public EmailNotificador(ConfiguracoesApp configuracoesApp)
        {
            this._configuracoesApp = configuracoesApp;
        }

        public void Notificar(string destinatario, string assunto, string conteudo)
        {
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(this._configuracoesApp.AWS.Email.Remetente, this._configuracoesApp.AWS.Email.NomeRemetente);
            message.To.Add(new MailAddress(destinatario));
            message.Subject = assunto;
            message.Body = conteudo;

            // Create and configure a new SmtpClient
            SmtpClient client =
                new SmtpClient(this._configuracoesApp.AWS.Email.Servidor, this._configuracoesApp.AWS.Email.Porta);
            // Pass SMTP credentials
            client.Credentials =
                new NetworkCredential(this._configuracoesApp.AWS.Email.Usuario, this._configuracoesApp.AWS.Email.Senha);
            //// Enable SSL encryption
            client.EnableSsl = true;

            client.Send(message);
        }
    }
}
