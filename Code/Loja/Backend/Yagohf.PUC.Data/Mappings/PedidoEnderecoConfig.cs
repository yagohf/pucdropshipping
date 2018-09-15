using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PedidoEnderecoConfig : IEntityTypeConfiguration<PedidoEndereco>
    {
        public void Configure(EntityTypeBuilder<PedidoEndereco> builder)
        {
            builder.ToTable("PedidoEndereco", "dbo");
            builder.HasKey(x => x.IdPedido);

            builder.Property(x => x.IdPedido)
  .HasColumnName("IdPedido")
  .IsRequired();

            builder.Property(x => x.Logradouro)
.HasColumnName("Logradouro")
.IsRequired();

            builder.Property(x => x.Numero)
.HasColumnName("Numero")
.IsRequired();

            builder.Property(x => x.Observacao)
.HasColumnName("Observacao");

            builder.Property(x => x.Bairro)
.HasColumnName("Bairro")
.IsRequired();

            builder.Property(x => x.Cidade)
.HasColumnName("Cidade")
.IsRequired();

            builder.Property(x => x.Estado)
.HasColumnName("Estado")
.IsRequired();

            builder.Property(x => x.CEP)
.HasColumnName("CEP")
.IsRequired();
        }
    }
}
