using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Service.Interface.Dominio
{
    public interface IPedidoService
    {
        bool VerificarFornecedorResponsavelPorPedido(int idFornecedorLogado, string chavePedidoFornecedor);
        Task<EventoPedidoFornecedorRegistrado> RegistrarEvento(int idFornecedorAutenticado, RegistroEventoPedidoFornecedor evento);
    }
}
