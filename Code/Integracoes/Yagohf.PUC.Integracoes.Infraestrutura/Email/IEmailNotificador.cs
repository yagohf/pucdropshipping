using System.Threading.Tasks;

namespace Yagohf.PUC.Integracoes.Infraestrutura.Email
{
    public interface IEmailNotificador
    {
        Task Notificar(string destinatario, string assunto, string conteudo);
    }
}
