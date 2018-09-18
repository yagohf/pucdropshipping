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
        private readonly ConfiguracoesApp _configuracoesApp;

        public BusinessMapProfile(ConfiguracoesApp configuracoesApp) : this("BusinessMapProfile", configuracoesApp)
        {
            
        }

        protected BusinessMapProfile(string profileName, ConfiguracoesApp configuracoesApp) : base(profileName)
        {
            this._configuracoesApp = configuracoesApp;

            this.MapearDTOsParaEntidades();
            this.MapearEntidadesParaDTOs();
        }

        private void MapearEntidadesParaDTOs()
        {
            //Produto.
            CreateMap<ProdutoCategoria, ProdutoCategoriaDTO>();
            CreateMap<Produto, ProdutoCatalogoDTO>()
                .ForMember(dto => dto.UrlImagem, config => config.MapFrom(entidade => $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensProdutos}/{entidade.Id}/main.jpg")); ;

            //Promoção.
            CreateMap<Promocao, PromocaoDTO>()
                .ForMember(dto=> dto.UrlImagem, config=> config.MapFrom(entidade=> $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensPromocoes}/{entidade.Id}/main.jpg"));

            //Propaganda.
            CreateMap<Propaganda, PropagandaDTO>()
                .ForMember(dto => dto.UrlImagem, config => config.MapFrom(entidade => $"{this._configuracoesApp.ServidorArquivosEstaticos.CaminhoImagensPropagandas}/{entidade.Id}/main.jpg"));

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
