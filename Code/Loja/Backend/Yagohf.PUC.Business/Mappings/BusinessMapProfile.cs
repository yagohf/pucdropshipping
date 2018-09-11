using AutoMapper;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Business.Mappings
{
    public class BusinessMapProfile : Profile
    {
        public BusinessMapProfile() : this("BusinessMapProfile")
        {
        }

        protected BusinessMapProfile(string profileName) : base(profileName)
        {
            this.MapearDTOsParaEntidades();
            this.MapearEntidadesParaDTOs();
        }

        private void MapearEntidadesParaDTOs()
        {
            //Produto.
            CreateMap<Produto, ProdutoCatalogoDTO>();
        }

        private void MapearDTOsParaEntidades()
        {
            //Produto.
            CreateMap<ProdutoCatalogoDTO, Produto>();
        }
    }
}
