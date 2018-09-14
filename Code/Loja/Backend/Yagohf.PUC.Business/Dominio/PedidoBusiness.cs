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

        public async Task<Listagem<PedidoListagemClienteDTO>> ListarPorClienteAsync(int cliente, int pagina)
        {
            throw new NotImplementedException();
        }

        public async Task<Listagem<PedidoListagemVendedorDTO>> ListarPorVendedorAsync(int vendedor, int pagina)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificarFornecedorResponsavelPorPedido(int idFornecedorLogado, string chavePedidoFornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
