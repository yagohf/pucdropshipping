using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.Produto;
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

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarAsync(string nome, string ordenacao, int pagina)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ProdutoCatalogoDTO>> ListarMaisVendidosAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarPorCategoriaAsync(int categoria, string ordenacao, int pagina)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Listagem<ProdutoCatalogoDTO>> ListarPorPromocao(int promocao, string ordenacao, int pagina)
        {
            throw new System.NotImplementedException();
        }
    }
}
