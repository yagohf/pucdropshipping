using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PromocaoConfig : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("Promocao", "dbo");
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

            builder.Property(x => x.DataInicio)
            .HasColumnName("DataInicio")
            .IsRequired();

            builder.Property(x => x.DataFim)
          .HasColumnName("DataFim");

            builder.Property(x => x.DataFimPrevisto)
          .HasColumnName("DataFimPrevisto");
        }
    }
}
