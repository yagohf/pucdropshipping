using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdCliente)
             .HasColumnName("IdCliente")
             .IsRequired();

            builder.Property(x => x.IdVendedor)
             .HasColumnName("IdVendedor");

            builder.Property(x => x.Data)
            .HasColumnName("Data")
            .IsRequired();

            builder.Property(x => x.ValorProdutos)
           .HasColumnName("ValorProdutos")
             .HasColumnType("decimal(20, 2)")
           .IsRequired();

            builder.Property(x => x.Desconto)
         .HasColumnName("Desconto")
           .HasColumnType("decimal(20, 2)")
         .IsRequired();

            builder.Property(x => x.ValorPago)
     .HasColumnName("ValorPago")
       .HasColumnType("decimal(20, 2)")
     .IsRequired();
        }
    }
}
