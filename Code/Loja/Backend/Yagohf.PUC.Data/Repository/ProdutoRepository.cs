using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LojaDbContext context) : base(context)
        {
        }

        public async Task<Listagem<Produto>> ListarParaCatalogoAsync(string nome, string ordenacao, int pagina)
        {
            var query = from prod in this._context.Set<Produto>().AsNoTracking()
                        select prod;

            int totalRegistros = await query.CountAsync();
            var lista = await query.ToListAsync();
            return new Listagem<Produto>(lista, new Paginacao(pagina, totalRegistros, QTD_REGISTROS_DEFAULT_PAGINACAO));
        }
    }
}
