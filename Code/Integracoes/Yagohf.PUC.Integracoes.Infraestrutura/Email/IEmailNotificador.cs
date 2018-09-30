namespace Yagohf.PUC.Integracoes.Infraestrutura.Email
{
    public interface IEmailNotificador
    {
        void Notificar(string destinatario, string assunto, string conteudo);
    }
}
