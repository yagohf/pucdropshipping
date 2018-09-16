using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Infraestrutura;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IProdutoBusiness
    {
        Task<Listagem<ProdutoCatalogoDTO>> ListarCatalogoAsync(string nome, string ordenacao, int pagina);
        Task<IEnumerable<ProdutoCatalogoDTO>> ListarCatalogoMaisVendidosAsync(int quantidadeRegistrosExibir);
        Task<Listagem<ProdutoCatalogoDTO>> ListarCatalogoPorCategoriaAsync(int categoria, string ordenacao, int pagina);
        Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoPorPromocaoAsync(int promocao, string ordenacao, int pagina);
    }
}
