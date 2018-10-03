using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class ProdutoCategoriaRepository : RepositoryBase<ProdutoCategoria>, IProdutoCategoriaRepository
    {
        public ProdutoCategoriaRepository(LojaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProdutoCategoriaDTO>> ListarTodasComQuantidadeProdutos()
        {
            var query = from cat in this._context.Set<ProdutoCategoria>().AsNoTracking()
                        join prod in 
                        (from p in this._context.Set<Produto>().AsNoTracking()
                         where p.Ativo && p.Disponivel
                         group p by p.IdProdutoCategoria into produtos_agrupados
                        select new { IdCategoria = produtos_agrupados.Key, Quantidade = produtos_agrupados.Count() }
                        )
                        on cat.Id equals prod.IdCategoria into join_cat_prod
                        from item_join_cat_prod in join_cat_prod.DefaultIfEmpty()
                        select new ProdutoCategoriaDTO()
                        {
                            Id = cat.Id,
                            Nome = cat.Nome,
                            QtdProdutos = item_join_cat_prod != null ? item_join_cat_prod.Quantidade : 0
                        };

            return await query.ToListAsync();
        }
    }
}
