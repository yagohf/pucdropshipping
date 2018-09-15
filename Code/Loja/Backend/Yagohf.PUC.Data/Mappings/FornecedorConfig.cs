using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class FornecedorConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Ativo)
.HasColumnName("Ativo")
.IsRequired();

            builder.Property(x => x.EnderecoConsultarEstoque)
.HasColumnName("EnderecoConsultarEstoque")
.IsRequired();

            builder.Property(x => x.EnderecoRealizarPedido)
.HasColumnName("EnderecoRealizarPedido")
.IsRequired();

            builder.Property(x => x.EnderecoCancelarPedido)
.HasColumnName("EnderecoCancelarPedido")
.IsRequired();

            //Relacionamentos
            builder.HasMany(x => x.PedidosFornecedor)
            .WithOne(x => x.Fornecedor)
            .HasForeignKey(x => x.IdFornecedor);
        }
    }
}
