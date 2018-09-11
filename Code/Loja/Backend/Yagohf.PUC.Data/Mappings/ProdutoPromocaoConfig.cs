using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class ProdutoPromocaoConfig : IEntityTypeConfiguration<ProdutoPromocao>
    {
        public void Configure(EntityTypeBuilder<ProdutoPromocao> builder)
        {
            builder.ToTable("ProdutoPromocao", "dbo");
            builder.HasKey(x => new { x.IdProduto, x.IdPromocao });

            builder.Property(x => x.IdProduto)
               .HasColumnName("IdProduto")
               .IsRequired();

            builder.Property(x => x.IdPromocao)
               .HasColumnName("IdPromocao")
               .IsRequired();

            builder.Property(x => x.PrecoVenda)
           .HasColumnName("PrecoVenda")
           .HasColumnType("decimal(20, 2)")
           .IsRequired();

            //Relacionamentos.
            builder.HasOne(x => x.Produto)
                .WithMany(x => x.PromocoesProduto)
                .HasForeignKey(x => x.IdProduto);

            builder.HasOne(x => x.Promocao)
                .WithMany(x => x.ProdutosPromocao)
                .HasForeignKey(x => x.IdPromocao);
        }
    }
}
