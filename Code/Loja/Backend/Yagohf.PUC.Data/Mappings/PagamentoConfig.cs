using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PagamentoConfig : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdProduto)
         .HasColumnName("IdProduto")
         .IsRequired();

            builder.Property(x => x.IdPagamentoStatus)
    .HasColumnName("IdPagamentoStatus")
    .IsRequired();

            builder.Property(x => x.ChaveTransacao)
.HasColumnName("ChaveTransacao")
.IsRequired();

            builder.Property(x => x.DescricaoPagamento)
.HasColumnName("DescricaoPagamento")
.IsRequired();

            builder.Property(x => x.XMLTransacao)
.HasColumnName("XMLTransacao")
.IsRequired();
        }
    }
}
