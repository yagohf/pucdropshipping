using AutoMapper;
using Yagohf.PUC.Infraestrutura.Configuration;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;
using Yagohf.PUC.Model.DTO.Promocao;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Business.Mappings
{
    public class BusinessMapProfile : Profile
    {
        private readonly IServidorArquivosEstaticosConfiguration _configServidorArquivosEstaticos;

        public BusinessMapProfile(IServidorArquivosEstaticosConfiguration configServidorArquivosEstaticos) : this("BusinessMapProfile", configServidorArquivosEstaticos)
        {
            
        }

        protected BusinessMapProfile(string profileName, IServidorArquivosEstaticosConfiguration configServidorArquivosEstaticos) : base(profileName)
        {
            this._configServidorArquivosEstaticos = configServidorArquivosEstaticos;

            this.MapearDTOsParaEntidades();
            this.MapearEntidadesParaDTOs();
        }

        private void MapearEntidadesParaDTOs()
        {
            //Produto.
            CreateMap<ProdutoCategoria, ProdutoCategoriaDTO>();
            CreateMap<Promocao, PromocaoDTO>()
                .ForMember(dto=> dto.UrlImagem, config=> config.MapFrom(entidade=> $"{this._configServidorArquivosEstaticos.CaminhoImagensPromocoes}/{entidade.Id}/main.jpg"));
        }

        private void MapearDTOsParaEntidades()
        {
           
        }
    }
}
