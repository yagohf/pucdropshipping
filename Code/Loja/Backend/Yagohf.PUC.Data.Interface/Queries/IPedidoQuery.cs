using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Queries
{
    public interface IPedidoQuery
    {
        IQuery<Pedido> PorCliente(int cliente);
        IQuery<Pedido> PorVendedor(int vendedor);
    }
}
