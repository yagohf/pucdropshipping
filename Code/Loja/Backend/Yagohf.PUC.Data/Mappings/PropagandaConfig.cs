using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PropagandaConfig : IEntityTypeConfiguration<Propaganda>
    {
        public void Configure(EntityTypeBuilder<Propaganda> builder)
        {
            builder.ToTable("Propaganda", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Posicao)
           .HasColumnName("Posicao")
           .IsRequired();

            builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .IsRequired();

            builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();

            builder.Property(x => x.Url)
            .HasColumnName("Url")
            .IsRequired();

            builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();
        }
    }
}
