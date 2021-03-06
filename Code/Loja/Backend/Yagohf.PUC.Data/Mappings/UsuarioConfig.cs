﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yagohf.PUC.Model.Entidades;

namespace Yagohf.PUC.Data.Mappings
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("Id")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Login)
.HasColumnName("Login")
.IsRequired();

            //Relacionamentos
            builder.HasOne(x => x.Pessoa)
              .WithOne(x => x.Usuario)
              .HasForeignKey<Pessoa>(x => x.IdUsuario);
        }
    }
}
