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
            return await this._produtoRepository.ListarParaCatalogoAsync(nome, ordenacao, pagina);
        }

        public async Task<IEnumerable<ProdutoCatalogoDTO>> ListarCatalogoMaisVendidosAsync(int quantidadeRegistrosExibir)
        {
            return await this._produtoRepository.ListarMaisVendidosParaCatalogoAsync(quantidadeRegistrosExibir);
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarCatalogoPorCategoriaAsync(int categoria, string ordenacao, int pagina)
        {
            return await this._produtoRepository.ListarParaCatalogoPorCategoriaAsync(categoria, ordenacao, pagina);
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarParaCatalogoPorPromocaoAsync(int promocao, string ordenacao, int pagina)
        {
            return await this._produtoRepository.ListarParaCatalogoPorPromocaoAsync(promocao, ordenacao, pagina);
        }
    }
}
