using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PagamentoStatusConfig : IEntityTypeConfiguration<PagamentoStatus>
    {
        public void Configure(EntityTypeBuilder<PagamentoStatus> builder)
        {
            builder.ToTable("PagamentoStatus", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
          .HasColumnName("Nome")
          .IsRequired();

            builder.Property(x => x.Descricao)
       .HasColumnName("Descricao")
       .IsRequired();
        }
    }
}
