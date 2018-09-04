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
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}