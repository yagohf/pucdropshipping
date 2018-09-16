using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Data.Interface.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoAsync(string nome, string ordenacao, int pagina);
        Task<IEnumerable<ProdutoCatalogoDTO>> ListarMaisVendidosParaCatalogoAsync(int quantidadeRegistrosExibir);
        Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoPorCategoriaAsync(int categoria, string ordenacao, int pagina);
        Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoPorPromocaoAsync(int promocao, string ordenacao, int pagina);
    }
}
