using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PagamentoEventoConfig : IEntityTypeConfiguration<PagamentoEvento>
    {
        public void Configure(EntityTypeBuilder<PagamentoEvento> builder)
        {
            builder.ToTable("PagamentoEvento", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdPagamento)
      .HasColumnName("IdPagamento")
      .IsRequired();

            builder.Property(x => x.IdPagamentoStatus)
     .HasColumnName("IdPagamentoStatus")
     .IsRequired();

            builder.Property(x => x.DataRecebimento)
   .HasColumnName("DataRecebimento")
   .IsRequired();

            builder.Property(x => x.XMLTransacao)
.HasColumnName("XMLTransacao")
.IsRequired();
        }
    }
}
