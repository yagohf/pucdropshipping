﻿using Yagohf.PUC.Data.Context;
using Yagohf.PUC.Data.Interface.Repository;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Repository
{
    public class PedidoFornecedorEventoRepository : RepositoryBase<PedidoFornecedorEvento>, IPedidoFornecedorEventoRepository
    {
        public PedidoFornecedorEventoRepository(LojaDbContext context) : base(context)
        {
        }
    }
}
