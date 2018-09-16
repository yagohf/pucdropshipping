using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.DTO.PedidoFornecedor;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IPedidoBusiness
    {
        Task<EventoPedidoFornecedorRegistradoDTO> RegistrarEventoAsync(int idFornecedorAutenticado, RegistroEventoPedidoFornecedorDTO evento);
        Task<Listagem<PedidoListagemClienteDTO>> ListarPorClienteAsync(int cliente, int pagina);
        Task<Listagem<PedidoListagemVendedorDTO>> ListarPorVendedorAsync(int vendedor, int pagina);
        Task<bool> VerificarFornecedorResponsavelPorPedido(int idFornecedorLogado, string chavePedidoFornecedor);
    }
}
