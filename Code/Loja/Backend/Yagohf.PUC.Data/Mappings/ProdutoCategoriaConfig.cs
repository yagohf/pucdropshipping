using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class ProdutoCategoriaConfig : IEntityTypeConfiguration<ProdutoCategoria>
    {
        public void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            builder.ToTable("ProdutoCategoria", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .HasColumnName("Id")
              .IsRequired()
              .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();

            builder.Property(x => x.Nome)
            .HasColumnName("Descricao")
            .IsRequired();
        }
    }
}
