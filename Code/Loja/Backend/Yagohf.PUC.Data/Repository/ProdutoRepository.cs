using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        private readonly ConfigAdapter _configuracoesApp;

        public ProdutoRepository(ConfigAdapter configuracoesApp, LojaDbContext context) : base(context)
        {
            this._configuracoesApp = configuracoesApp;
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
                        where (string.IsNullOrEmpty(nome) || (!string.IsNullOrEmpty(nome) && prod.Nome.Contains(nome))) && prod.Ativo && prod.Disponivel
                        select new ProdutoCatalogoDTO()
                        {
                            Id = prod.Id,
                            Nome = prod.Nome,
                            Descricao = prod.Descricao,
                            Disponivel = prod.Disponivel,
                            Preco = (item_join_prod_p_prom_prom != null && item_join_prod_p_prom_prom.Ativa ? item_join_prod_p_prom.PrecoVenda : prod.PrecoVenda),
                            UrlImagem = $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensProdutos}/{prod.Id}/main.jpg"
                        };

            query = OrdenarQueryCatalogo(ordenacao, query);
            return await PaginarQueryCatalogo(query, pagina);
        }

        public async Task<IEnumerable<ProdutoCatalogoDTO>> ListarMaisVendidosParaCatalogoAsync(int quantidadeRegistrosExibir)
        {
            var query = from id_produto_vendido in
                        (from ip in this._context.Set<PedidoItem>().AsNoTracking()
                        group ip by ip.IdProduto into itens_vendidos_agrupados
                        orderby itens_vendidos_agrupados.Count() descending
                        select itens_vendidos_agrupados.Key)
                        join prod in this._context.Set<Produto>().AsNoTracking()
                          on id_produto_vendido equals prod.Id
                        join p_prom in this._context.Set<ProdutoPromocao>().AsNoTracking()
                          on prod.Id equals p_prom.IdProduto into join_prod_p_prom
                        from item_join_prod_p_prom in join_prod_p_prom.DefaultIfEmpty()
                        join prom in this._context.Set<Promocao>().AsNoTracking()
                          on item_join_prod_p_prom.IdPromocao equals prom.Id into join_prod_p_prom_prom
                        from item_join_prod_p_prom_prom in join_prod_p_prom_prom.DefaultIfEmpty()
                        where prod.Ativo && prod.Disponivel
                        select new ProdutoCatalogoDTO()
                        {
                            Id = prod.Id,
                            Nome = prod.Nome,
                            Descricao = prod.Descricao,
                            Disponivel = prod.Disponivel,
                            Preco = (item_join_prod_p_prom_prom != null && item_join_prod_p_prom_prom.Ativa ? item_join_prod_p_prom.PrecoVenda : prod.PrecoVenda),
                            UrlImagem = $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensProdutos}/{prod.Id}/main.jpg"
                        };

            return await query.Take(quantidadeRegistrosExibir).ToListAsync();
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoPorCategoriaAsync(int categoria, string ordenacao, int pagina)
        {
            var query = from prod in this._context.Set<Produto>().AsNoTracking()
                        join p_prom in this._context.Set<ProdutoPromocao>().AsNoTracking()
                          on prod.Id equals p_prom.IdProduto into join_prod_p_prom
                        from item_join_prod_p_prom in join_prod_p_prom.DefaultIfEmpty()
                        join prom in this._context.Set<Promocao>().AsNoTracking()
                          on item_join_prod_p_prom.IdPromocao equals prom.Id into join_prod_p_prom_prom
                        from item_join_prod_p_prom_prom in join_prod_p_prom_prom.DefaultIfEmpty()
                        where prod.IdProdutoCategoria == categoria && prod.Ativo && prod.Disponivel
                        select new ProdutoCatalogoDTO()
                        {
                            Id = prod.Id,
                            Nome = prod.Nome,
                            Descricao = prod.Descricao,
                            Disponivel = prod.Disponivel,
                            Preco = (item_join_prod_p_prom_prom != null && item_join_prod_p_prom_prom.Ativa ? item_join_prod_p_prom.PrecoVenda : prod.PrecoVenda),
                            UrlImagem = $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensProdutos}/{prod.Id}/main.jpg"
                        };

            query = OrdenarQueryCatalogo(ordenacao, query);
            return await PaginarQueryCatalogo(query, pagina);
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoPorPromocaoAsync(int promocao, string ordenacao, int pagina)
        {
            var query = from prod in this._context.Set<Produto>().AsNoTracking()
                        join p_prom in this._context.Set<ProdutoPromocao>().AsNoTracking()
                          on prod.Id equals p_prom.IdProduto into join_prod_p_prom
                        from item_join_prod_p_prom in join_prod_p_prom
                        join prom in this._context.Set<Promocao>().AsNoTracking()
                          on item_join_prod_p_prom.IdPromocao equals prom.Id into join_prod_p_prom_prom
                        from item_join_prod_p_prom_prom in join_prod_p_prom_prom
                        where item_join_prod_p_prom_prom.Id == promocao && prod.Ativo && prod.Disponivel
                        select new ProdutoCatalogoDTO()
                        {
                            Id = prod.Id,
                            Nome = prod.Nome,
                            Descricao = prod.Descricao,
                            Disponivel = prod.Disponivel,
                            Preco = (item_join_prod_p_prom_prom != null && item_join_prod_p_prom_prom.Ativa ? item_join_prod_p_prom.PrecoVenda : prod.PrecoVenda),
                            UrlImagem = $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensProdutos}/{prod.Id}/main.jpg"
                        };

            query = OrdenarQueryCatalogo(ordenacao, query);
            return await PaginarQueryCatalogo(query, pagina);
        }

        #region [ Auxiliares ]
        private IQueryable<ProdutoCatalogoDTO> OrdenarQueryCatalogo(string ordenacao, IQueryable<ProdutoCatalogoDTO> query)
        {
            if (!string.IsNullOrEmpty(ordenacao))
            {
                switch (ordenacao.ToUpper())
                {
                    case "PRECO_ASC":
                        query = query.OrderBy(x => x.Preco);
                        break;
                    case "PRECO_DESC":
                        query = query.OrderByDescending(x => x.Preco);
                        break;
                }
            }

            return query;
        }

        private async Task<Listagem<ProdutoCatalogoDTO>> PaginarQueryCatalogo(IQueryable<ProdutoCatalogoDTO> query, int pagina)
        {
            int totalRegistros = await query.CountAsync();
            var lista = await query.Skip(QTD_REGISTROS_DEFAULT_PAGINACAO * (pagina - 1)).Take(QTD_REGISTROS_DEFAULT_PAGINACAO).ToListAsync();
            return new Listagem<ProdutoCatalogoDTO>(lista, new Paginacao(pagina, totalRegistros, QTD_REGISTROS_DEFAULT_PAGINACAO));
        } 
        #endregion
    }
}
