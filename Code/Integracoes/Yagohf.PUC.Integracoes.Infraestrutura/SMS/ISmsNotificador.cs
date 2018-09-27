using System.Threading.Tasks;

namespace Yagohf.PUC.Integracoes.Infraestrutura.SMS
{
    public interface ISmsNotificador
    {
        Task Notificar(string nroTelefone, string texto);
    }
}
