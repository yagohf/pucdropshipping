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
            modelBuilder.ApplyConfiguration(new ProdutoCategoriaConfig());
            modelBuilder.ApplyConfiguration(new ProdutoPromocaoConfig());
            modelBuilder.ApplyConfiguration(new PromocaoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new PropagandaConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}