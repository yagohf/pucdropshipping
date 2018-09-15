using Microsoft.EntityFrameworkCore;
using Yagohf.PUC.Data.Mappings;

namespace Yagohf.PUC.Data.Context
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext(DbContextOptions<LojaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Adicionar configurações.
            modelBuilder.ApplyConfiguration(new FornecedorConfig());
            modelBuilder.ApplyConfiguration(new PagamentoConfig());
            modelBuilder.ApplyConfiguration(new PagamentoEstornoConfig());
            modelBuilder.ApplyConfiguration(new PagamentoEventoConfig());
            modelBuilder.ApplyConfiguration(new PagamentoStatusConfig());
            modelBuilder.ApplyConfiguration(new PedidoConfig());
            modelBuilder.ApplyConfiguration(new PedidoEnderecoConfig());
            modelBuilder.ApplyConfiguration(new PedidoFornecedorConfig());
            modelBuilder.ApplyConfiguration(new PedidoFornecedorEventoConfig());
            modelBuilder.ApplyConfiguration(new PedidoFornecedorStatusConfig());
            modelBuilder.ApplyConfiguration(new PedidoItemAvaliacaoConfig());
            modelBuilder.ApplyConfiguration(new PedidoItemConfig());
            modelBuilder.ApplyConfiguration(new PerfilConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoCategoriaConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoPromocaoConfig());
            modelBuilder.ApplyConfiguration(new PromocaoConfig());
            modelBuilder.ApplyConfiguration(new PropagandaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new UsuarioPerfilConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}