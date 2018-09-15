using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PessoaEnderecoConfig : IEntityTypeConfiguration<PessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
        {
            builder.ToTable("PessoaEndereco", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(x => x.IdPessoa)
  .HasColumnName("IdPessoa")
  .IsRequired();

            builder.Property(x => x.Apelido)
.HasColumnName("Apelido")
.IsRequired();

            builder.Property(x => x.Logradouro)
.HasColumnName("Logradouro")
.IsRequired();

            builder.Property(x => x.Numero)
.HasColumnName("Numero")
.IsRequired();

            builder.Property(x => x.Observacao)
.HasColumnName("Observacao");

            builder.Property(x => x.Bairro)
.HasColumnName("Bairro")
.IsRequired();

            builder.Property(x => x.Cidade)
.HasColumnName("Cidade")
.IsRequired();

            builder.Property(x => x.Estado)
.HasColumnName("Estado")
.IsRequired();

            builder.Property(x => x.CEP)
.HasColumnName("CEP")
.IsRequired();
        }
    }
}
