using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Queries
{
    public interface IPedidoQuery
    {
        IQuery<Pedido> PorCliente(string cliente);
        IQuery<Pedido> PorVendedor(string vendedor);
    }
}
