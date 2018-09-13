using System;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.DTO.PedidoFornecedor;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Dominio
{
    public class PedidoBusiness : IPedidoBusiness
    {
        public async Task<EventoPedidoFornecedorRegistradoDTO> Registrar(int idFornecedorAutenticado, RegistroEventoPedidoFornecedorDTO evento)
        {
            throw new NotImplementedException();
        }

        public async Task<Listagem<PedidoDTO>> ListarAsync(int usuario, int pagina)
        {
            throw new NotImplementedException();
        }
    }
}
