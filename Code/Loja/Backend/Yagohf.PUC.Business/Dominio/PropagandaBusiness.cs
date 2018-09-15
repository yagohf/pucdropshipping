using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.Propaganda;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Business.Dominio
{
    public class PropagandaBusiness : IPropagandaBusiness
    {
        private readonly IPropagandaRepository _propagandaRepository;
        private readonly IPropagandaQuery _propagandaQuery;
        private IMapper _mapper;

        public PropagandaBusiness(IPropagandaRepository propagandaRepository, IPropagandaQuery propagandaQuery, IMapper mapper)
        {
            this._propagandaRepository = propagandaRepository;
            this._propagandaQuery = propagandaQuery;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<PropagandaDTO>> ListarTodasAtivasAsync()
        {
            var propagandas = await this._propagandaRepository.ListarAsync(this._propagandaQuery.ListarAtivas());
            return propagandas.Mapear<Propaganda, PropagandaDTO>(this._mapper);
        }
    }
}
