using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;

namespace Yagohf.PUC.Business.Interface.Dominio
{
    public interface IProdutoCategoriaBusiness
    {
        Task<IEnumerable<ProdutoCategoriaDTO>> ListarTodosAsync();
    }
}
