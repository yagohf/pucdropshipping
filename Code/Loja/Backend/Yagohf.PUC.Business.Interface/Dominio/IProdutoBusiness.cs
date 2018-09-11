using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Infraestrutura;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IProdutoBusiness
    {
        Task<Listagem<ProdutoCatalogoDTO>> ListarAsync(string nome, string ordenacao, int pagina);
        Task<IEnumerable<ProdutoCatalogoDTO>> ListarMaisVendidosAsync();
        Task<Listagem<ProdutoCatalogoDTO>> ListarPorCategoriaAsync(int categoria, string ordenacao, int pagina);
        Task<Listagem<ProdutoCatalogoDTO>> ListarPorPromocao(int promocao, string ordenacao, int pagina);
    }
}
