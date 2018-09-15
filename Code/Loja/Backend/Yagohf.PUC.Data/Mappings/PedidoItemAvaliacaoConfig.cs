using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PedidoItemAvaliacaoConfig : IEntityTypeConfiguration<PedidoItemAvaliacao>
    {
        public void Configure(EntityTypeBuilder<PedidoItemAvaliacao> builder)
        {
            builder.ToTable("PedidoItemAvaliacao", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Classificacao)
      .HasColumnName("Classificacao")
      .IsRequired();

            builder.Property(x => x.DescricaoAvaliacao)
  .HasColumnName("DescricaoAvaliacao")
  .IsRequired();

            builder.Property(x => x.IdPedidoItem)
.HasColumnName("IdPedidoItem")
.IsRequired();
        }
    }
}
