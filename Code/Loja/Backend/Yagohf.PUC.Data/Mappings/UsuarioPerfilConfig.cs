using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class UsuarioPerfilConfig : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.ToTable("UsuarioPerfil", "dbo");
            builder.HasKey(x => new { x.IdPerfil, x.IdUsuario });

            builder.Property(x => x.IdUsuario)
.HasColumnName("IdUsuario")
.IsRequired();

            builder.Property(x => x.IdPerfil)
.HasColumnName("IdPerfil")
.IsRequired();

            //Relacionamentos
            builder.HasOne(x => x.Usuario)
             .WithMany(x => x.UsuarioPerfis)
             .HasForeignKey(x => x.IdUsuario);

            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.UsuarioPerfis)
                .HasForeignKey(x => x.IdPerfil);
        }
    }
}
