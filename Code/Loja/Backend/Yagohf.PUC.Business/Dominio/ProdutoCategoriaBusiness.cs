using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Business.Dominio
{
    public class ProdutoCategoriaBusiness : IProdutoCategoriaBusiness
    {
        private readonly IProdutoCategoriaRepository _produtoCategoriaRepository;
        private readonly IMapper _mapper;

        public ProdutoCategoriaBusiness(IProdutoCategoriaRepository produtoCategoriaRepository, IMapper mapper)
        {
            this._produtoCategoriaRepository = produtoCategoriaRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoCategoriaDTO>> ListarTodosAsync()
        {
            var produtos = await this._produtoCategoriaRepository.ListarTodosAsync();
            return produtos.Mapear<ProdutoCategoria, ProdutoCategoriaDTO>(this._mapper);
        }
    }
}
