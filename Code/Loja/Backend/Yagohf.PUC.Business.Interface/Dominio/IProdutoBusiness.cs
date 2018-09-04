using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Infraestrutura;
using System.Threading.Tasks;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IProdutoBusiness
    {
        Task<Listagem<ProdutoDTO>> ListarAsync(string nome, decimal? avaliacaoMinima, string ordenacao, int pagina);
        Task<Listagem<ProdutoDTO>> ListarMaisVendidosAsync();
        Task<Listagem<ProdutoDTO>> ListarPorCategoriaAsync(int categoria);
    }
}
