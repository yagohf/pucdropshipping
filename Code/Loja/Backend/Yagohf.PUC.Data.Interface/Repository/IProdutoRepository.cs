using System.Threading.Tasks;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Data.Interface.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Listagem<Produto>> ListarParaCatalogoAsync(string nome, string ordenacao, int pagina);
    }
}
