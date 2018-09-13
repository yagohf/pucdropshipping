using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.DTO.PedidoFornecedor;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IPedidoBusiness
    {
        Task<EventoPedidoFornecedorRegistradoDTO> Registrar(int idFornecedorAutenticado, RegistroEventoPedidoFornecedorDTO evento);
        Task<Listagem<PedidoDTO>> ListarAsync(int usuario, int pagina);
    }
}
