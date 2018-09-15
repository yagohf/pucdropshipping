using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PedidoFornecedorConfig : IEntityTypeConfiguration<PedidoFornecedor>
    {
        public void Configure(EntityTypeBuilder<PedidoFornecedor> builder)
        {
            builder.ToTable("PedidoFornecedor", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdFornecedor)
             .HasColumnName("IdFornecedor")
             .IsRequired();

            builder.Property(x => x.IdPedidoItem)
           .HasColumnName("IdPedidoItem")
           .IsRequired();

            builder.Property(x => x.ChavePedidoFornecedor)
           .HasColumnName("ChavePedidoFornecedor")
           .IsRequired();

            builder.Property(x => x.IdPedidoFornecedorStatus)
           .HasColumnName("IdPedidoFornecedorStatus")
           .IsRequired();
        }
    }
}
