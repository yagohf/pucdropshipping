using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.Promocao;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Business.Dominio
{
    public class PromocaoBusiness : IPromocaoBusiness
    {
        private readonly IPromocaoRepository _promocaoRepository;
        private readonly IPromocaoQuery _promocaoQuery;
        private readonly IMapper _mapper;

        public PromocaoBusiness(IPromocaoRepository promocaoRepository, IPromocaoQuery promocaoQuery, IMapper mapper)
        {
            this._promocaoRepository = promocaoRepository;
            this._promocaoQuery = promocaoQuery;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<PromocaoDTO>> ListarTodasAtivasAsync()
        {
            var promocoes = await this._promocaoRepository.ListarAsync(this._promocaoQuery.ListarAtivas());
            return promocoes.Mapear<Promocao, PromocaoDTO>(this._mapper);
        }
    }
}
