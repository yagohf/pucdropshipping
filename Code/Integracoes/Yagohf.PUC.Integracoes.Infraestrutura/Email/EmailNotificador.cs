using System;
using System.Threading.Tasks;

namespace Yagohf.PUC.Integracoes.Infraestrutura.Email
{
    public class EmailNotificador : IEmailNotificador
    {
        public Task Notificar(string destinatario, string assunto, string conteudo)
        {
            throw new NotImplementedException();
        }
    }
}
