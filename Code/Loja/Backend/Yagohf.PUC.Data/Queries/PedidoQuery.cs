using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Queries
{
    public class PedidoQuery : IPedidoQuery
    {
        public IQuery<Pedido> PorCliente(string cliente)
        {
            return new Query<Pedido>()
                .Filtrar(x => x.Cliente.Usuario.Login == cliente)
                .AdicionarInclude("Cliente.Usuario")
                .OrdenarPorDescendente(x => x.Data);
        }

        public IQuery<Pedido> PorVendedor(string vendedor)
        {
            return new Query<Pedido>()
               .Filtrar(x => x.Vendedor.Usuario.Login == vendedor)
               .AdicionarInclude("Vendedor.Usuario")
               .OrdenarPorDescendente(x => x.Data);
        }
    }
}
