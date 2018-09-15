using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PedidoItemConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(x => x.IdPedido)
.HasColumnName("IdPedido")
.IsRequired();

            builder.Property(x => x.IdProduto)
.HasColumnName("IdProduto")
.IsRequired();

            builder.Property(x => x.PrecoCusto)
.HasColumnName("PrecoCusto")
.IsRequired();

            builder.Property(x => x.PrecoVenda)
.HasColumnName("PrecoVenda")
.IsRequired();

            builder.Property(x => x.Quantidade)
.HasColumnName("Quantidade")
.IsRequired();

            builder.Property(x => x.Desconto)
.HasColumnName("Desconto")
.IsRequired();

            builder.Property(x => x.PrecoFinal)
.HasColumnName("PrecoFinal")
.IsRequired();

            //Relacionamentos
            builder.HasOne(x => x.PedidoItemAvaliacao)
          .WithOne(x => x.PedidoItem)
          .HasForeignKey<PedidoItemAvaliacao>(x => x.IdPedidoItem);

            builder.HasOne(x => x.PagamentoEstorno)
       .WithOne(x => x.PedidoItem)
       .HasForeignKey<PagamentoEstorno>(x => x.IdPedidoItem);

            builder.HasOne(x => x.PedidoFornecedor)
   .WithOne(x => x.PedidoItem)
   .HasForeignKey<PedidoFornecedor>(x => x.IdPedidoItem);

            builder.HasOne(x => x.Produto)
.WithMany(x => x.PedidoItens)
.HasForeignKey(x => x.IdProduto);
        }
    }
}
