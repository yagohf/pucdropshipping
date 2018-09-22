using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Interface.Repository
{
    public interface IProdutoCategoriaRepository : IRepository<ProdutoCategoria>
    {
        Task<IEnumerable<ProdutoCategoriaDTO>> ListarTodasComQuantidadeProdutos();
    }
}
