using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(x => x.IdUsuario)
.HasColumnName("IdUsuario");

            builder.Property(x => x.Nome)
.HasColumnName("Nome")
.IsRequired();

            builder.Property(x => x.Email)
.HasColumnName("Email")
.IsRequired();

            builder.Property(x => x.Telefone)
.HasColumnName("Telefone");

            builder.Property(x => x.Documento)
.HasColumnName("Documento")
.IsRequired();

            //Relacionamentos
            builder.HasMany(x => x.PessoaEnderecos)
              .WithOne(x => x.Pessoa)
              .HasForeignKey(x => x.IdPessoa);

            builder.HasOne(x => x.Fornecedor)
           .WithOne(x => x.Pessoa)
           .HasForeignKey<Fornecedor>(x => x.Id);
        }
    }
}
