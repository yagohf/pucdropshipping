﻿using AutoMapper;
using System.Threading.Tasks;
using Yagohf.PUC.Business.Extensions;
using Yagohf.PUC.Business.Interface.Dominio;
using Yagohf.PUC.Data.Interface.Queries;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.DTO.Pedido;
using Yagohf.PUC.Model.Entidades;
using Yagohf.PUC.Model.Infraestrutura;

namespace Yagohf.PUC.Business.Dominio
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoQuery _pedidoQuery;
        private readonly IMapper _mapper;
        protected const int QTD_REGISTROS_DEFAULT_PAGINACAO = 9;

        public PedidoBusiness(IPedidoRepository pedidoRepository, IPedidoQuery pedidoQuery, IMapper mapper)
        {
            this._pedidoRepository = pedidoRepository;
            this._pedidoQuery = pedidoQuery;
            this._mapper = mapper;
        }

        public async Task<Listagem<PedidoListagemClienteDTO>> ListarPorClienteAsync(string cliente, int pagina)
        {
            var lista = await this._pedidoRepository.ListarPaginandoAsync(this._pedidoQuery.PorCliente(cliente), pagina, QTD_REGISTROS_DEFAULT_PAGINACAO);
            return lista.Mapear<Pedido, PedidoListagemClienteDTO>(this._mapper);
        }

        public async Task<Listagem<PedidoListagemVendedorDTO>> ListarPorVendedorAsync(string vendedor, int pagina)
        {
            var lista = await this._pedidoRepository.ListarPaginandoAsync(this._pedidoQuery.PorVendedor(vendedor), pagina, QTD_REGISTROS_DEFAULT_PAGINACAO);
            return lista.Mapear<Pedido, PedidoListagemVendedorDTO>(this._mapper);
        }
    }
}
