using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PagamentoEstornoConfig : IEntityTypeConfiguration<PagamentoEstorno>
    {
        public void Configure(EntityTypeBuilder<PagamentoEstorno> builder)
        {
            builder.ToTable("PagamentoEstorno", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdPagamento)
      .HasColumnName("IdPagamento")
      .IsRequired();

            builder.Property(x => x.IdPedidoItem)
     .HasColumnName("IdPedidoItem")
     .IsRequired();

            builder.Property(x => x.Data)
.HasColumnName("Data")
.IsRequired();

            builder.Property(x => x.Valor)
.HasColumnName("Valor")
.IsRequired();

            builder.Property(x => x.XMLTransacao)
.HasColumnName("XMLTransacao")
.IsRequired();
        }
    }
}
