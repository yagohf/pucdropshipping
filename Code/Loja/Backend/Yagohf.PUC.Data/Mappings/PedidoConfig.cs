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

            //Relacionamentos.
            builder.HasOne(x => x.Pagamento)
               .WithOne(x => x.Pedido)
               .HasForeignKey<Pagamento>(x => x.IdPedido);

            builder.HasOne(x => x.PedidoEndereco)
               .WithOne(x => x.Pedido)
               .HasForeignKey<PedidoEndereco>(x => x.IdPedido);

            builder.HasOne(x => x.Cliente)
             .WithMany(x => x.Compras)
             .HasForeignKey(x => x.IdCliente);

            builder.HasOne(x => x.Vendedor)
          .WithMany(x => x.Vendas)
          .HasForeignKey(x => x.IdVendedor);

            builder.HasMany(x => x.PedidoItens)
       .WithOne(x => x.Pedido)
       .HasForeignKey(x => x.IdPedido);
        }
    }
}
