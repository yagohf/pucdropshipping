using AutoMapper;
using Yagohf.PUC.Infraestrutura.Configuration;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.DTO.Produto;
using Yagohf.PUC.Model.DTO.ProdutoCategoria;
using Yagohf.PUC.Model.DTO.Promocao;
using Yagohf.PUC.Model.DTO.Propaganda;
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
            CreateMap<Produto, ProdutoCatalogoDTO>()
                .ForMember(dto => dto.UrlImagem, config => config.MapFrom(entidade => $"{this._configServidorArquivosEstaticos.CaminhoImagensProdutos}/{entidade.Id}/main.jpg")); ;

            //Promoção.
            CreateMap<Promocao, PromocaoDTO>()
                .ForMember(dto=> dto.UrlImagem, config=> config.MapFrom(entidade=> $"{this._configServidorArquivosEstaticos.CaminhoImagensPromocoes}/{entidade.Id}/main.jpg"));

            //Propaganda.
            CreateMap<Propaganda, PropagandaDTO>()
                .ForMember(dto => dto.UrlImagem, config => config.MapFrom(entidade => $"{this._configServidorArquivosEstaticos.CaminhoImagensPropagandas}/{entidade.Id}/main.jpg"));

            //Pedido.
            CreateMap<Pedido, PedidoListagemClienteDTO>()
                .ForMember(dto => dto.Valor, config => config.MapFrom(entidade => entidade.ValorPago));
            CreateMap<Pedido, PedidoListagemVendedorDTO>()
               .ForMember(dto => dto.Valor, config => config.MapFrom(entidade => entidade.ValorPago))
               .ForMember(dto => dto.NomeCliente, config => config.MapFrom(entidade => entidade.Cliente.Nome));
        }

        private void MapearDTOsParaEntidades()
        {
           
        }
    }
}
