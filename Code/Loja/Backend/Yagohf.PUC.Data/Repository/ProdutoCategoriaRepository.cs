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
                        join prod in this._context.Set<Produto>().AsNoTracking()
                          on cat.Id equals prod.IdProdutoCategoria into join_cat_prod
                        from item_join_cat_prod in join_cat_prod.DefaultIfEmpty()
                        group cat by new { cat.Id, cat.Nome } into categorias_agrupadas
                        orderby categorias_agrupadas.Key.Nome
                        select new ProdutoCategoriaDTO()
                        {
                            Id = categorias_agrupadas.Key.Id,
                            Nome = categorias_agrupadas.Key.Nome,
                            QtdProdutos = categorias_agrupadas.Count()
                        };

            return await query.ToListAsync();
        }
    }
}
