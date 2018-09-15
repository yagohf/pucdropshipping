using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PedidoFornecedorEventoConfig : IEntityTypeConfiguration<PedidoFornecedorEvento>
    {
        public void Configure(EntityTypeBuilder<PedidoFornecedorEvento> builder)
        {
            builder.ToTable("PedidoFornecedorEvento", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdPedidoFornecedor)
           .HasColumnName("IdPedidoFornecedor")
           .IsRequired();

            builder.Property(x => x.IdPedidoFornecedorStatus)
       .HasColumnName("IdPedidoFornecedorStatus")
       .IsRequired();

            builder.Property(x => x.DataOcorrencia)
    .HasColumnName("DataOcorrencia")
    .IsRequired();

            builder.Property(x => x.InformacoesAdicionais)
.HasColumnName("InformacoesAdicionais");

            //Relacionamentos
            builder.HasOne(x => x.PedidoFornecedorStatus)
          .WithMany(x => x.PedidosFornecedoresEventos)
          .HasForeignKey(x => x.IdPedidoFornecedorStatus);
        }
    }
}
