using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IPedidoBusiness
    {
        Task<Listagem<PedidoListagemClienteDTO>> ListarPorClienteAsync(string cliente, int pagina);
        Task<Listagem<PedidoListagemVendedorDTO>> ListarPorVendedorAsync(string vendedor, int pagina);
    }
}
