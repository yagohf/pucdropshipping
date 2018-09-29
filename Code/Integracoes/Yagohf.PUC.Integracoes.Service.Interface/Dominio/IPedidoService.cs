using System.Threading.Tasks;
using Yagohf.PUC.Integracoes.Model;

namespace Yagohf.PUC.Integracoes.Service.Interface.Dominio
{
    public interface IPedidoService
    {
        bool VerificarFornecedorResponsavelPorPedido(string fornecedorLogado, string chavePedidoFornecedor);
        Task<EventoPedidoFornecedorRegistrado> RegistrarEvento(string fornecedorAutenticado, RegistroEventoPedidoFornecedor evento);
    }
}
