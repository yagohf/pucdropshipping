using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Dominio
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoBusiness(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarCatalogoAsync(string nome, string ordenacao, int pagina)
        {
            var produtos = await this._produtoRepository.ListarParaCatalogoAsync(nome, ordenacao, pagina);
            return produtos.Mapear<Produto, ProdutoCatalogoDTO>(this._mapper);
        }

        public async Task<IEnumerable<ProdutoCatalogoDTO>> ListarCatalogoMaisVendidosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarCatalogoPorCategoriaAsync(int categoria, string ordenacao, int pagina)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarCatalogoPorPromocao(int promocao, string ordenacao, int pagina)
        {
            throw new System.NotImplementedException();
        }
    }
}
