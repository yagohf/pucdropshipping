using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdFornecedor)
             .HasColumnName("IdFornecedor")
             .IsRequired();

            builder.Property(x => x.ChaveProdutoFornecedor)
             .HasColumnName("ChaveProdutoFornecedor")
             .IsRequired();

            builder.Property(x => x.Nome)
             .HasColumnName("Nome")
             .IsRequired();

            builder.Property(x => x.Descricao)
             .HasColumnName("Descricao")
             .IsRequired();

            builder.Property(x => x.Disponivel)
             .HasColumnName("Disponivel")
             .IsRequired();

            builder.Property(x => x.PrecoCusto)
             .HasColumnName("PrecoCusto")
             .HasColumnType("decimal(20, 2)")
             .IsRequired();

            builder.Property(x => x.PrecoVenda)
             .HasColumnName("PrecoVenda")
             .HasColumnType("decimal(20, 2)")
             .IsRequired();

            builder.Property(x => x.DataCadastro)
              .HasColumnName("DataCadastro")
              .IsRequired();

            builder.Property(x => x.IdProdutoCategoria)
              .HasColumnName("IdProdutoCategoria")
              .IsRequired();

            builder.Property(x => x.Ativo)
              .HasColumnName("Ativo")
              .IsRequired();

            //Relacionamentos.
            builder.HasOne(x => x.ProdutoCategoria)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.IdProdutoCategoria);

            builder.HasOne(x => x.Fornecedor)
               .WithMany(x => x.Produtos)
               .HasForeignKey(x => x.IdFornecedor);
        }
    }
}
