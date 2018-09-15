using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Infraestrutura.Configuration;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        private readonly IServidorArquivosEstaticosConfiguration _configServidorArquivosEstaticos;

        public ProdutoRepository(IServidorArquivosEstaticosConfiguration configServidorArquivosEstaticos, LojaDbContext context) : base(context)
        {
            this._configServidorArquivosEstaticos = configServidorArquivosEstaticos;
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoAsync(string nome, string ordenacao, int pagina)
        {
            var query = from prod in this._context.Set<Produto>().AsNoTracking()
                        join p_prom in this._context.Set<ProdutoPromocao>().AsNoTracking()
                          on prod.Id equals p_prom.IdProduto into join_prod_p_prom
                        from item_join_prod_p_prom in join_prod_p_prom.DefaultIfEmpty()
                        join prom in this._context.Set<Promocao>().AsNoTracking()
                          on item_join_prod_p_prom.IdPromocao equals prom.Id into join_prod_p_prom_prom
                        from item_join_prod_p_prom_prom in join_prod_p_prom_prom.DefaultIfEmpty()
                        where (string.IsNullOrEmpty(nome) || (!string.IsNullOrEmpty(nome) && prod.Nome.Contains(nome)))
                        select new ProdutoCatalogoDTO()
                        {
                            Id = prod.Id,
                            Nome = prod.Nome,
                            Disponivel = prod.Disponivel,
                            Preco = (item_join_prod_p_prom_prom != null && item_join_prod_p_prom_prom.Ativa ? item_join_prod_p_prom.PrecoVenda : prod.PrecoVenda),
                            UrlImagem = $"{this._configServidorArquivosEstaticos.CaminhoImagensPropagandas}/{prod.Id}/main.jpg"
                        };

            switch (ordenacao)
            {
                case "PRECO_ASC":
                    query = query.OrderBy(x => x.Preco);
                    break;
                case "PRECO_DESC":
                    query = query.OrderByDescending(x => x.Preco);
                    break;
            }

            int totalRegistros = await query.CountAsync();
            var lista = await query.Skip(QTD_REGISTROS_DEFAULT_PAGINACAO * (pagina -1)).Take(QTD_REGISTROS_DEFAULT_PAGINACAO).ToListAsync();
            return new Listagem<ProdutoCatalogoDTO>(lista, new Paginacao(pagina, totalRegistros, QTD_REGISTROS_DEFAULT_PAGINACAO));
        }
    }
}
