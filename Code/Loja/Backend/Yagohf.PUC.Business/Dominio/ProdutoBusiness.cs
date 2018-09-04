using AutoMapper;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Dominio
{
    public class ProdutoBusiness : IProdutoBusiness
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoQuery _produtoQuery;
        private readonly IMapper _mapper;

        public ProdutoBusiness(IProdutoRepository produtoRepository, IProdutoQuery produtoQuery, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._produtoQuery = produtoQuery;
            this._mapper = mapper;
        }

        public async Task<Listagem<ProdutoDTO>> ListarAsync(string nome, decimal? avaliacaoMinima, string ordenacao, int pagina)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Listagem<ProdutoDTO>> ListarMaisVendidosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Listagem<ProdutoDTO>> ListarPorCategoriaAsync(int categoria)
        {
            throw new System.NotImplementedException();
        }
    }
}
