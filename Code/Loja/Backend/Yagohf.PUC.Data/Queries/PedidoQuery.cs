using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Queries
{
    public class PedidoQuery : IPedidoQuery
    {
        public IQuery<Pedido> PorCliente(int cliente)
        {
            return new Query<Pedido>()
                .Filtrar(x => x.IdCliente == cliente)
                .OrdenarPorDescendente(x => x.Data);
        }

        public IQuery<Pedido> PorVendedor(int vendedor)
        {
            return new Query<Pedido>()
               .Filtrar(x => x.IdVendedor == vendedor)
               .AdicionarInclude(x => x.Cliente)
               .OrdenarPorDescendente(x => x.Data);
        }
    }
}
